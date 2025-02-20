namespace h_work.lesson93.Example1;

public class Before
{
    /*
     * public async Task Validate(IBankOnboardingContext context, BankOnboardingStepContext stepContext,
        FreelancerBusinessDetailsExecuteDataContract contract)
    {
        contract.ContractNotNull("contract");
        contract.AgreeToTerms.ContractEqual(true, "AgreeToTerms is not selected");
        
        var regDateIsMandatory = await _features.IsAvailableAsync(EFeatures.FreelancerRegDateIsMandatory, context.CountryCode);
        if (contract.RegistrationDate != null || regDateIsMandatory)
        {
            contract.RegistrationDate.ValidateRegistrationDate();
        }
    }
    
    public static void ValidateRegistrationDate(this DateTime? registrationDate)
        {
            ValidationRuleFactory.CreateSet(() => registrationDate)
                .WithRule(x => x.NotNull()
                    .SetException(() => new ContractValidationException("RegistrationDate", null)
                    {
                        DefaultText = "Registration date is required.",
                        Key = "common.validators.registrationDateRequired",
                    }))
                .WithRule(x => x.Value.LessThanOrEqualTo(DateTime.Today)
                    .SetException(() => new ContractValidationException("RegistrationDate", null)
                    {
                        DefaultText = "Registration date must be less current date.",
                        Key = "common.validators.registrationDateLessNow",
                    }))
                .ValidateAndThrow();
        }
     */
}