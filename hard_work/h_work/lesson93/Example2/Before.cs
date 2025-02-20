namespace h_work.lesson93.Example2;

/*
public interface IMobileValidator
{
    void Run(string phoneCode, string phone);
}

public class SpainMobileValidator : IMobileValidator
{
    public void Run(string phoneCode, string phone)
    {
        string trimPhone = MobilePhoneHelper.Trim(phone);
        trimPhone.Length(9, 9)
            .SetException(() => new ContractValidationException("Phone",
                "Spanish mobile phone number is 9 digits.")
            {
                DefaultText = "Spanish mobile phone number is 9 digits.",
                Key = "common.validators.spanishMobilePhoneLength",
            })
            .ValidateAndThrow();

        string fullphone = MobilePhoneHelper.Trim(phoneCode + phone);
        bool isValidPhone = Regex.IsMatch(fullphone, @"^\+?34[6][0-9]{8}$",
            RegexOptions.Compiled, TimeSpan.FromSeconds(2))
            || Regex.IsMatch(fullphone, @"^\+?34[7][1-9]{1}[0-9]{7}$",
                RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        var defaultText = MobileValidationTextTemplates.IncorrectPhone("Spanish");
        isValidPhone.Equal(true)
            .SetException(() => new ContractValidationException("Phone",
                defaultText)
            {
                DefaultText = defaultText,
                Key = "common.validators.spanishMobilePhoneIncorrect",
            })
            .ValidateAndThrow();
    }
}

*/