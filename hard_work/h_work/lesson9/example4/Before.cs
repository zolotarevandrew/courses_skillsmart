using System.Text.RegularExpressions;

namespace h_work.lesson9.example4;

public static class BankOnbooardingAddressHelper
{
    public static async Task<string> TrimAddress(
        string countryCode, string countyCode, string city,
        string address, string postcode,
        IDictionariesService dictionariesService, string lang = "EN")
    {
        countryCode = countryCode.ToUpper();
        string result = ReplaceWord(address ?? string.Empty, city);
        result = ReplaceWord(result, postcode);
        if (countryCode == "IT")
        {
            result = ReplaceWord(result, countyCode);
            int index = Provinces.ItalyProvinces.FindIndex(x =>
                x.Code.Equals(countyCode, StringComparison.OrdinalIgnoreCase));
            if (index > -1)
            {
                result = ReplaceWord(result, Provinces.ItalyProvinces[index].Name);
            }
        }

        var country = await dictionariesService.GetCountry(countryCode, lang);
        result = ReplaceWord(result, country.Name);

        result = Regex.Replace(result, @"\s+,+", ", ", RegexOptions.Compiled, TimeSpan.FromSeconds(5));
        result = Regex.Replace(result, @",+", ", ", RegexOptions.Compiled, TimeSpan.FromSeconds(5));
        return result.Trim(',', ' ');
    }

    private static string ReplaceWord(string source, string word, string target = ",")
    {
        word = word == null ? string.Empty : Regex.Escape(word);
        return Regex.Replace(source,
            $@"[\s,.]+{word}[\s,.]+|^{word}[\s,.]+|(?<!-){word}$",
            target, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));
    }
}

public interface IDictionariesService
{
    Task<Country> GetCountry(string countryCode, string lang);
}

public class Country
{
    public string Name { get; set; }
}

public class Provinces
{
    public static List<Province> ItalyProvinces { get; set; } = new();
}

public class Province
{
    public string Name { get; set; }
    public string Code { get; set; }
}