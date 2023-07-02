using System.Text.RegularExpressions;

namespace h_work.lesson11.example2;

public static class MobilePhoneHelper
{

    public static string FormatE164(string phoneCode, string phone)
    {
        if (!string.IsNullOrWhiteSpace(phoneCode) &&
            !string.IsNullOrWhiteSpace(phone))
        {
            return $"+{phoneCode}{phone}";
        }

        return string.Empty;
    }

    public static string Trim(string txt)
    {
        if (string.IsNullOrEmpty(txt))
        {
            return txt;
        }

        return Regex.Replace(txt, @"[^0-9]+", "",
            RegexOptions.Compiled, TimeSpan.FromSeconds(2));
    }
}