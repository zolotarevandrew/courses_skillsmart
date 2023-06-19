

using h_work.lesson9.example6;

namespace h_work.lesson9.example3;

public class ReflectionsTempDataSettor
{
    private readonly IPropertiesExtractor _propertiesExtractor;
    private readonly IValueSettorFactory _valueSettorFactory;

    public ReflectionsTempDataSettor(IPropertiesExtractor propertiesExtractor,
        IValueSettorFactory valueSettorFactory)
    {
        _propertiesExtractor = propertiesExtractor;
        _valueSettorFactory = valueSettorFactory;
    }

    public async Task SetData<T>(ValueSettorContext context,
        T contract, IEnumerable<ITempDataEntity> tempData)
    {
        if (contract != null)
        {
            List<PropertyExtractData> props = _propertiesExtractor.GetPropertiesAllowedForTempData(
                contract);
            foreach (ITempDataEntity entity in tempData)
            {
                if (!string.IsNullOrWhiteSpace(entity?.Key))
                {
                    await TempDataEntityProcessing(context, contract, props, entity);
                }
            }
        }
    }

    private async Task TempDataEntityProcessing<T>(ValueSettorContext context,
        T contract, List<PropertyExtractData> props, ITempDataEntity entity)
    {
        PropertyExtractData property = props.FirstOrDefault(x =>
            x.Attribute.Equals(entity.Key, StringComparison.OrdinalIgnoreCase));
        if (property != null)
        {
            IValueSettor valueSettor = _valueSettorFactory.GetSettor(property);
            if (valueSettor != null)
            {
                await SafeSetValue(context, contract, entity, property, valueSettor);
            }
        }
    }

    private async Task SafeSetValue<T>(
        ValueSettorContext context,
        T contract, ITempDataEntity entity,
        PropertyExtractData property, 
        IValueSettor valueSettor)
    {
        try
        {
            await valueSettor.Set(context, contract, property, entity.Value);
        }
        catch (Exception ex)
        {
            //logging was here
        }
    }
}

public interface IValueSettorFactory
{
    IValueSettor GetSettor(PropertyExtractData property);
}

public class PropertyExtractData
{
    public string Attribute { get; set; }
}

public class ValueSettorContext
{
    public IBankOnboardingContext OnboardingContext { get; }
}

public interface ITempDataEntity
{
    public string Key { get; }
    public object Value { get; }
}

public interface IValueSettor
{
    Task Set<T>(ValueSettorContext context, T contract, PropertyExtractData property, object entityValue);
}

public interface IPropertiesExtractor
{
    List<PropertyExtractData> GetPropertiesAllowedForTempData<T>(T contract);
}