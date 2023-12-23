using h_work.lesson18.part1.example2;

namespace h_work.lesson31.example5;

public interface IRegNumberService
{
    Task<string> Get(IBankOnboardingContext context);
    Task Set(IBankOnboardingContext context, string regnumber);
}

public class RegNumberService : IRegNumberService
{
    private readonly IBankOnboardingMetadataService _metadata;

    public RegNumberService(IBankOnboardingMetadataService metadata)
    {
        _metadata = metadata;
    }

    public Task<string> Get(IBankOnboardingContext context)
    {
        return _metadata.GetKey<string>(context, "RegNumber");
    }

    public Task Set(IBankOnboardingContext context, string regnumber)
    {
        return _metadata.SetKey(context, "RegNumber", regnumber);
    }
}

public interface IBankOnboardingMetadataService
{
    Task<T> GetKey<T>(IBankOnboardingContext context, string key);
    Task SetKey<T>(IBankOnboardingContext context, string key, T value);
}