using System.Text.RegularExpressions;

namespace h_work.lesson1.example1;

public class TypeOfActivityItem
{
    public string Id { get; set; }
    public string SearchRow { get; set; }
    public int Order { get; set; }
}

public static class L1Example1
{
    //loaded from json file
    private static List<TypeOfActivityItem> _items = new List<TypeOfActivityItem>();
    
    private readonly static Regex _prepareQuery =
        new Regex(@"[\W]", RegexOptions.Compiled, TimeSpan.FromSeconds(3));

    private readonly static Regex _digitsQuery =
        new Regex(@"\d{5,}", RegexOptions.Compiled, TimeSpan.FromSeconds(3));

    public static IEnumerable<TypeOfActivityItem> Search(string query)
    {
        IEnumerable<TypeOfActivityItem> items = _items.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(query))
        {
            string preparedQuery = _prepareQuery.Replace(query, "").ToUpper();
            string numbers = _digitsQuery.Match(preparedQuery).ToString();

            if (!string.IsNullOrEmpty(numbers))
            {
                preparedQuery = _digitsQuery.Replace(preparedQuery, numbers.Substring(0, 4), 1);
            }

            if (preparedQuery.Length > 0)
            {
                items = items.Where(x => x.SearchRow.IndexOf(preparedQuery) > -1);
            }
        }

        return items.OrderBy(x => x.Order);
    }
}