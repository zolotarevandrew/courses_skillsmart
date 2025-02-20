using System.Text.RegularExpressions;

namespace h_work.lesson93.Example2;

public interface IMobileValidator
{
    IEnumerable<MobileValidationError> Run(string phoneCode, string phone);
}

public class MobileValidationError(string Code, string DefaultText, string Localization);

public class SpainMobileValidator : IMobileValidator
{
    public IEnumerable<MobileValidationError> Run(string phoneCode, string phone)
    {
        string trimPhone = phone.Trim();
        
        if (trimPhone.Length > 9)
            yield return new MobileValidationError("Phone", "Spanish mobile phone number is 9 digits.", "common.validators.spanishMobilePhoneLength");

        string fullphone = (phoneCode + phone).Trim();
        bool isValidPhone = Regex.IsMatch(fullphone, @"^\+?34[6][0-9]{8}$",
                                RegexOptions.Compiled, TimeSpan.FromSeconds(2))
                            || Regex.IsMatch(fullphone, @"^\+?34[7][1-9]{1}[0-9]{7}$",
                                RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        if (!isValidPhone) 
            yield return new MobileValidationError("Phone", "Incorrect phone", "common.validators.spanishMobilePhoneIncorrect");
    }
}