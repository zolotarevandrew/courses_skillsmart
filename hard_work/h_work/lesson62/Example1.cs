using System.Text.RegularExpressions;

namespace h_work.lesson62;

public class Example1
{
    const char Quote = '"';
    const char Semicolon = ';';
    const string SemicolonStr = ";";
    
    private static string[] DetectValuesBefore(string line)
    {
        List<string> result = new List<string>();
        bool inside = false;
        int index = 0;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == Semicolon && !inside)
            {
                result.Add(line[index..i].Trim(Quote));
                index = i + 1;
            }

            if (line[i] == Quote)
            {
                inside = !inside;
            }
        }

        if (index != line.Length)
        {
            result.Add(line[index..].Trim(Quote));
        }

        return result.ToArray();
    }

    private static IEnumerable<string> DetectValuesAfter(string line)
    {
        var pattern = "\"[^\"]*\"|\\w+|[^\\w\\s]";
        RegexOptions options = RegexOptions.Multiline;
        
        var values = Regex.Matches(line, pattern, options)
            .Where( c => c.Value != SemicolonStr)
            .Select(c => c.Value);
        return values;
        
    }
}