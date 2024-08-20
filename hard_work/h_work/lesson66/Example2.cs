using System.Text.RegularExpressions;

namespace h_work.lesson66;

public record GoogleAddressLine
{
    private const string Pattern = "\"[^\"]*\"|\\w+|[^\\w\\s]";
    private const string Separator = ";";
    
    private readonly string _city;
    private readonly string _street;
    private readonly string _postCode;
    
    public GoogleAddressLine(string value)
    {
        var splitted = Regex.Matches(value, Pattern, RegexOptions.Multiline)
            .Where( c => c.Value != Separator)
            .Select(c => c.Value)
            .ToArray();
        
        _city = splitted[0];
        _street = splitted[1];
        _postCode = splitted[2];
    }

    //или сделать record для деконструции, без разницы
    public (string City, string Street, string PostCode) Value => (_city, _street, _postCode);

}