namespace h_work.lesson18.part2.example1;

public class OnboardingPerson
{
    public Guid Id { get; set; }
}

public class OnboardingRegistrator : OnboardingPerson
{
    public Guid UserId { get; set; }
}

public class LegalRep : OnboardingPerson
{
    
}
public class PersonVerificationsCalculatorV2
{
    public async Task<List<OnboardingPerson>> Calc(IBankOnboardingContext context, OnboardingRegistrator registrator)
    {
        if (registrator == null) throw new InvalidOperationException("registrator should be provided");
        
        List<LegalRepresentative> lrs = await GetAllLegalRepresentavies(context);
        //just for safety
        var withoutRegistrator = lrs
            .Where(c => c.Id != registrator.Id);

        var othersForVerification = CalcOthersNeedForVerification(withoutRegistrator);
        
        return new List<OnboardingPerson>()
        {
            registrator
        }.Concat(othersForVerification).ToList();
    }

    private List<OnboardingPerson> CalcOthersNeedForVerification(IEnumerable<LegalRepresentative> withoutRegistrator)
    {
        throw new NotImplementedException();
    }

    private async Task<List<LegalRepresentative>> GetAllLegalRepresentavies(IBankOnboardingContext context)
    {
        throw new NotImplementedException();
    }
}