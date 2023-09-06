namespace h_work.lesson20.example1;

public abstract class AobBanner
{
    protected AobBanner(string titleKey, int bankCode, int onboardingType, object payload)
    {
        BankCode = bankCode;
        OnboardingType = onboardingType;
        Payload = payload;
        TitleKey = titleKey;
    }
    public string TitleKey { get; set; }
    public object Payload { get; }
    public int BankCode { get; }
    public int OnboardingType { get; }
}

//обратная совместимость
public static class Extensions
{
    public static async Task<BankOnboardingAobStatusContract> ToOldContract(this AobBanner banner)
    {
        //тут всегда будет одна группа

        //пускай в первой реализации будет брать по типу названия баннера
        var type = banner.GetType().FullName.Replace("AobBanner", "");
        return new BankOnboardingAobStatusContract
        {
            GroupSteps = new List<BankOnboardingAobGroupStep>
            {
                new BankOnboardingAobGroupStep
                {
                    //заставим фронт еще смотреть по ключу в текст, чтобы не лазить с бэка
                    Title = banner.TitleKey
                }
            },

            Status = Enum.Parse<EBankOnboardingAobStatus>(type),
            Payload = banner.Payload,
            BankCode = banner.BankCode,
            OnboardingType = banner.OnboardingType
        };
    }
}

public class FinomReviewAobBanner : AobBanner
{
    public FinomReviewAobBanner(IBankOnboardingContext context) : base("somelocalizationkey", context.BankCode, context.OnboardingType, null)
    {


    }
}

public class AwaitingPricingSelectionAobBanner : AobBanner
{
    public AwaitingPricingSelectionAobBanner(IBankOnboardingContext context) : base("somelocalizationkey", context.BankCode, context.OnboardingType, null)
    {


    }
}

public class After
{
    async Task<AobBanner> Review(IBankOnboardingContext context, string lang)
    {
        if (await IsPricingNotCompleted(context))
        {
            return new AwaitingPricingSelectionAobBanner(context);
        }

        return new FinomReviewAobBanner(context);
    }

    private async Task<bool> IsPricingNotCompleted(IBankOnboardingContext context)
    {
        throw new System.NotImplementedException();
    }
}