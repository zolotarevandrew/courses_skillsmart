using Newtonsoft.Json;

namespace h_work.lesson31.example5;

public abstract class BankOnboardingMetadata
{
    public abstract string Key { get; }
    public abstract string Serialize();
}

public abstract class BankOnboardingMetadata<T> : BankOnboardingMetadata
{
    protected BankOnboardingMetadata(T value)
    {
        Value = value;
    }
    private T Value { get; }
    
    public override string Serialize()
    {
        return JsonConvert.SerializeObject(Value);
    }
}

public class RegNumberMetadata : BankOnboardingMetadata<string>
{
    public override string Key => "RegNumber";

    public RegNumberMetadata(string value) : base(value)
    {
    }
}


public interface IBankOnboardingMetadataServiceV2
{
    Task<TMetadata> Get<TMetadata>(Guid onboardingId) where TMetadata: BankOnboardingMetadata;
    Task Set<TMetadata>(Guid onboardingId, TMetadata metadata) where TMetadata: BankOnboardingMetadata;
}