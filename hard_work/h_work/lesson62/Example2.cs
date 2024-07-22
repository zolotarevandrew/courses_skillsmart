using System.Text.RegularExpressions;
using System.Xml;

namespace h_work.lesson62;

public class Example2
{
    public static void Before()
    {
        using var fileReader = File.OpenText("activities.csv");

        List<Row> data = new List<Row>();

        string line = fileReader.ReadLine();
        line = fileReader.ReadLine();
        int order = 1;
        while (line != null)
        {
            string[] row = line.Split(';');

            data.Add(new Row
            {
                Id = Guid.NewGuid(),
                Code = row[0][0] + " " + row[0][1..],
                EnDescription = row[1],
                ItDescription = row[3],
                EnKeyWords = row[2].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList(),
                SearchRow = Regex.Replace(line, @"[\W]", "").ToUpper(),
                Order = order++,
            });

            line = fileReader.ReadLine();
        }
    }

    public static void After()
    {
        var data = File.ReadLines("activities.csv")
            .Skip(1) // Skip header line
            .Select((line, index) => {
                string[] row = line.Split(';');

                return new Row
                {
                    Id = Guid.NewGuid(),
                    Code = row[0][0] + " " + row[0][1..],
                    EnDescription = row[1],
                    ItDescription = row[3],
                    EnKeyWords = row[2].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList(),
                    SearchRow = Regex.Replace(line, @"[\W]", "").ToUpper(),
                    Order = index + 1,
                };
            });
    }
    
    public class Row
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string EnDescription { get; set; }
        public string ItDescription { get; set; }
        public List<string> EnKeyWords { get; set; } = new List<string>();
        public string SearchRow { get; set; }
        public bool Enabled { get; set; } = true;
        public int Order { get; set; }
    }
}