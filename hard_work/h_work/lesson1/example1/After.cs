
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace h_work.lesson1.example1;

public class ActivitySearchQuery
{
    private static readonly Regex ReplaceNonWordsRegex = new(@"[\W]", RegexOptions.Compiled, TimeSpan.FromSeconds(1));
    private static readonly Regex FiveOrMoreDigitsRegex = new Regex(@"\d{5,}", RegexOptions.Compiled, TimeSpan.FromSeconds(3));
    
    public string Value { get; }
    public ActivitySearchQuery(string query)
    {
        Value = Transform(query, ReplaceNonWords, ReplaceToFourDigitsOnly);;
    }

    public string ReplaceNonWords(string query)
    {
        return ReplaceNonWordsRegex
            .Replace(query, "")
            .ToUpper();
    }

    public string ReplaceToFourDigitsOnly(string query)
    {
        return FiveOrMoreDigitsRegex.Replace(query, match => match.Value[..4], 1);
    }

    public string Transform(string query, params Func<string, string>[] funcs)
    {
        return funcs.Aggregate(query, (current, func) => func(current));
    }
}

public class TypeOfActivityDictionary
{
    private static List<TypeOfActivityItem> _items;

    static TypeOfActivityDictionary()
    {
        _items = LoadDict();
    }

    public IEnumerable<TypeOfActivityItem> Search(ActivitySearchQuery query)
    {
        if (string.IsNullOrEmpty(query.Value))
        {
            return Enumerable.Empty<TypeOfActivityItem>();
        }

        return _items
            .Where(x => x.SearchRow.IndexOf(query.Value, StringComparison.Ordinal) > -1)
            .OrderBy(x => x.Order);
    }

    static List<TypeOfActivityItem> LoadDict()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "lesson1", "example1", "ActivityCodes.json");
        var file = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<TypeOfActivityItem>>(file);
    }
}