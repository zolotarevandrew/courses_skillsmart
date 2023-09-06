namespace h_work.lesson20.example1;

public class BankOnboardingAobStatusContract
{
    public EBankOnboardingAobStatus Status { get; set; }
    public List<BankOnboardingAobGroupStep> GroupSteps { get; set; } = new();
    public object Payload { get; set; }
    public int BankCode { get; set; }
    public int OnboardingType { get; set; }
}

public class BankOnboardingAobGroupStep
{
    public string Title { get; set; }
}

public interface IBankOnboardingContext
{
    int BankCode { get; set; }
    int OnboardingType { get; set; }
}

public enum EBankOnboardingAobStatus
{
    Hidden = 1,
    AwaitingPricingSelection = 2,
    FinomReview = 3
}
public class Before
{
    async Task<BankOnboardingAobStatusContract> Review(IBankOnboardingContext context, string lang)
    {
        var aob = await GetAob(context);
        var aobStatus = CreateDefaultAobStatus(context);

        if (IsPricingNotCompleted(context, aob))
        {
            aobStatus.Status = EBankOnboardingAobStatus.AwaitingPricingSelection;
            aobStatus.GroupSteps.Add(aob.Group);
            aob.Group.Title = await GetGroupTitle("some.key", lang);
            return aobStatus;
        }

        aobStatus.Status = EBankOnboardingAobStatus.FinomReview;

        return aobStatus;
    }

    private async Task<string> GetGroupTitle(string someKey, string lang)
    {
        //localization key search
        throw new System.NotImplementedException();
    }

    private async Task<Aob> GetAob(IBankOnboardingContext context)
    {
        throw new System.NotImplementedException();
    }


    class Aob
    {
        public BankOnboardingAobGroupStep Group { get; set; }
        public bool Completed { get; set; }
        public bool HasErrors { get; set; }
    }

    static BankOnboardingAobStatusContract CreateDefaultAobStatus(IBankOnboardingContext context)
    {
        return new BankOnboardingAobStatusContract
        {
            Status = EBankOnboardingAobStatus.Hidden,
            BankCode = context.BankCode,
            OnboardingType = context.OnboardingType
        };
    }

    private bool IsPricingNotCompleted(IBankOnboardingContext context, object aob)
    {
        throw new System.NotImplementedException();
    }
}