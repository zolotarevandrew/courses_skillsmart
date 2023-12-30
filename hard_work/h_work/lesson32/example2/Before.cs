namespace h_work.lesson32.example2;

public static class CodiceFiscaleExtensions
{
    public static DateTime? GetBirthday(this string codeciFiscale)
    {
        DateTime? result = null;
        if (string.IsNullOrEmpty(codeciFiscale) || codeciFiscale.Length != 16)
        {
            return result;
        }
        
        int day = GetDay(codeciFiscale);
        if (day > 31)
        {
            day -= 40;
        }

        // 9 Month of birth
        char ch = codeciFiscale[8];
        int? month = char.ToUpper(ch) switch
        {
            'A' => 1,
            'B' => 2,
            'C' => 3,
            'D' => 4,
            'E' => 5,
            'H' => 6,
            'L' => 7,
            'M' => 8,
            'P' => 9,
            'R' => 10,
            'S' => 11,
            'T' => 12,
            _ => null,
        };

        // 7-8 Year of birth. Last two digits of the birth year(e.g., for customers born in 1975, these digits would be 75).
        if (month.HasValue && int.TryParse(codeciFiscale[6..8], out int y) && 0 <= y && y <= 99)
        {
            int year = y <= (DateTime.UtcNow.Year - 2000) ? 2000 + y : 1900 + y;
            return new DateTime(year, month.Value, day, 0, 0, 0, 0, DateTimeKind.Utc);
        }
        
        throw new InvalidOperationException("invalid codeciFiscale");
    }
    
    private static int GetDay(this string codeciFiscale)
    {
        if (int.TryParse(codeciFiscale[9..11], out int day)
            && (0 < day && day <= 31 || 40 < day && day <= 71))
        {
            return day;
        }

        throw new InvalidOperationException("invalid codeciFiscale");
    }
}