namespace h_work.lesson87.Example3;

/*
public record MobilePhone(string Code, string Phone)
{
    public string Full => FullNumber(Code, Phone);

    public static MobilePhone Create(string phoneCode, string phone)
    {
        //внутренняя функция валидации + дополнительная нормализация
        var res = MobilePhoneHelper.ValidateAndNormalizeV2(phoneCode.TrimStart('+'), GetFormattedPhoneNumber(phone));

        return new MobilePhone(res.phoneCode, res.phone);
    }
    
    private string GetFormattedPhoneNumber(string phoneNumber)
        {
            return phoneNumber.StartsWith("0") && phoneNumber.Length > 1 
                ? phoneNumber[1..] 
                : phoneNumber;
        }
}
*/