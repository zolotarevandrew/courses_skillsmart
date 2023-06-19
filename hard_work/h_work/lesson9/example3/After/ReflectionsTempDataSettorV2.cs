namespace h_work.lesson9.example3.After;

public class ReflectionsTempDataSettorV2
{
    private readonly IPropertiesExtractor _propertiesExtractor;
    private readonly IValueSettorFactory _valueSettorFactory;

    public ReflectionsTempDataSettorV2(
        IPropertiesExtractor propertiesExtractor,
        IValueSettorFactory valueSettorFactory)
    {
        _propertiesExtractor = propertiesExtractor;
        _valueSettorFactory = valueSettorFactory;
    }

    public async Task SetData<T>(ValueSettorContext context, T contract, IEnumerable<ITempDataEntity> tempData)
    {
        if (contract == null) return;
        
        List<PropertyExtractData> foundProperties = _propertiesExtractor.GetPropertiesAllowedForTempData(contract);
        var tasks = tempData
            .Where(tempEntity => !string.IsNullOrWhiteSpace(tempEntity.Key))
            .Select(tempEntity => GetSettor(foundProperties, tempEntity))
            .Select(props =>
            {
                var (property, entity, settor) = props;
                
                async Task SafeSetValue()
                {
                    try
                    {
                        await settor.Set(context, contract, property, entity.Value);
                    }
                    catch (Exception ex)
                    {
                        //there will also be nre exception if properties or settor was not found.. it shouldnt be like that.
                        //logging was here
                    }
                }
                
                return SafeSetValue();
            })
            .ToList();
        await Task.WhenAll(tasks);
    }

    (PropertyExtractData Property, ITempDataEntity Entity, IValueSettor Settor) GetSettor(List<PropertyExtractData> props, ITempDataEntity entity)
    {
        PropertyExtractData property = props.FirstOrDefault(x => x.Attribute.Equals(entity.Key, StringComparison.OrdinalIgnoreCase));
        //just check nullable property inside value settor factoryy..
        IValueSettor valueSettor = _valueSettorFactory.GetSettor(property);

        return (property, entity, valueSettor);
    }
}