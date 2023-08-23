namespace h_work.lesson18.part2.example1;

public class LegalRepresentative
{
    public Guid Id { get; set; }
}

public interface IBankOnboardingContext
{
    
}

public interface IOnboardingRegistrator
{
    Task<LegalRepresentative> Get(List<LegalRepresentative> legalRepresentatives);
}
public class PersonVerificationsCalculator
{
    private readonly IOnboardingRegistrator _registrator;

    public PersonVerificationsCalculator(IOnboardingRegistrator registrator)
    {
        _registrator = registrator;
    }
    public async Task<List<LegalRepresentative>> Calc(IBankOnboardingContext context)
    {
        List<LegalRepresentative> lrs = await GetAllLegalRepresentavies(context);
        var registrator = await _registrator.Get(lrs);
        var withoutRegistrator = lrs
            .Where(c => c.Id != registrator.Id);

        var othersForVerification = CalcOthersNeedForVerification(withoutRegistrator);
        
        return new List<LegalRepresentative>()
        {
            registrator
        }.Concat(othersForVerification).ToList();
    }

    private List<LegalRepresentative> CalcOthersNeedForVerification(IEnumerable<LegalRepresentative> withoutRegistrator)
    {
        throw new NotImplementedException();
    }

    private async Task<List<LegalRepresentative>> GetAllLegalRepresentavies(IBankOnboardingContext context)
    {
        throw new NotImplementedException();
    }
}