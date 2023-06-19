using System.Text.RegularExpressions;

namespace h_work.lesson9.example4.After;

public static class Example
{
    private static IDictionariesService _dictionariesService;
    public static async Task Run()
    {
        var postCode = new PostCode("123131");
        var countyCode = new CountyCode("IS");
        var city = new City("Rome");
        var country = await _dictionariesService.GetCountry("IT", "en");

        var addressLine = new AddressLine("IS, Rome, 123131, some data");
        addressLine
            .ClearFromLine(postCode.Value)
            .ClearFromLine(countyCode.Value)
            .ClearFromLine(city.Value)
            .ClearFromLine(country.Name);
    }
}

public record PostCode(string Value);
public record CountyCode(string Value);
public record City(string Value);

public record AddressLine
{
    private const string Replacement = ",";
    
    private readonly string _value;
    public AddressLine(string value)
    {
        _value = value;
    }

    public string Value => GetFormatted();
    
    public AddressLine ClearFromLine(string value)
    {
        var escaped = Regex.Escape(value ?? string.Empty);
        string pattern = $@"[\s,.]+{escaped}[\s,.]+|^{escaped}[\s,.]+|(?<!-){escaped}$";
        var replaced = Regex.Replace(_value, pattern, Replacement, RegexOptions.IgnoreCase);
        return new AddressLine(replaced);
    }
    
    string GetFormatted()
    {
        return _value
            .Trim(',', ' ')
            .Replace(",+", ", ")
            .Replace(@"\s+,+", ", ");
    }
}