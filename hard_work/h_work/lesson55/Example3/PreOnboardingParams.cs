namespace h_work.lesson55.Example3;

/*
 * public interface IPreOnboardingService
{
    Task AddParam(PreOnboardingParam param);
    Task<PreOnboardingParamSourceGroup> GetParamSourceGroup(Guid companyId);
    Task<PreOnboardingParamSource> GetParamSource(Guid companyId, EPreOnboardingParamType type);
}

public abstract class PreOnboardingParam
{
    protected PreOnboardingParam(EPreOnboardingParamType type, Guid companyId, JObject value)
    {
        Type = type;
        CompanyId = companyId;
        Value = value;
    }

    public Guid CompanyId { get; protected set; }
    public JObject Value { get; set; }
    public EPreOnboardingParamType Type { get; }
}

public abstract class PreOnboardingParam<T> : PreOnboardingParam where T : class
{
    public T ParamValue { get; private set; }

    protected PreOnboardingParam(EPreOnboardingParamType type, Guid companyId, T paramValue) : base(type, companyId,
        JObject.FromObject(paramValue))
    {
        ParamValue = paramValue;
    }

    public static bool TryBuildParamValue(PreOnboardingParamSource source, out T value)
    {
        value = source?.Value?.ToObject<T>();
        return value != null;
    }
}

public class GermanPrefferedOfferPreOnboardingParam : PreOnboardingParam<GermanPrefferedOfferIbanCountry>
{
    private const EPreOnboardingParamType ParamType = EPreOnboardingParamType.GermanPrefferedOffer;

    public GermanPrefferedOfferPreOnboardingParam(Guid companyId, GermanPrefferedOfferIbanCountry ibanCountry)
        : base(ParamType, companyId, ibanCountry)
    {
    }

    //we can use static interfaces here later...
    public static GermanPrefferedOfferPreOnboardingParam Create(PreOnboardingParamSourceGroup sourceGroup)
    {
        var param = sourceGroup.Get(ParamType);
        if (param == null) return null;

        if (!TryBuildParamValue(param, out var paramValue))
        {
            return null;
        }

        var ibanCountry = GermanPrefferedOfferIbanCountry.Create(paramValue.Country);
        if (ibanCountry == null) return null;

        return new GermanPrefferedOfferPreOnboardingParam(param.CompanyId, ibanCountry);
    }

    public static bool TryGetParam(PreOnboardingParamSourceGroup sourceGroup,
        out GermanPrefferedOfferPreOnboardingParam param)
    {
        param = Create(sourceGroup);
        return param != null;
    }
}

*/