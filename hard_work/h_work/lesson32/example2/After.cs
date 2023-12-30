namespace h_work.lesson32.example2;

public class CodiceFiscaleBirthDayPart
{
    private int? _value;
    public CodiceFiscaleBirthDayPart(int value)
    {
        _value = value;
        Error = string.Empty;
    }

    public CodiceFiscaleBirthDayPart(string error)
    {
        Error = error;
    }
    
    public bool IsError => !string.IsNullOrEmpty(Error);
    public string Error { get; }
    public int Value => _value.Value;
}

public record CodiceFiscaleBirthDay(CodiceFiscaleBirthDayPart Year, CodiceFiscaleBirthDayPart Month, CodiceFiscaleBirthDayPart Day)
{
    private static Range YearRange = 6..8;
    private static Range MonthRange = 8..8;
    private static Range DayRange = 9..11;
    
    public static CodiceFiscaleBirthDay FromString(string input)
    {
        return new CodiceFiscaleBirthDay(
            GetYear(SafeSubstring(input, YearRange)), 
            GetMonth(SafeSubstring(input, MonthRange)), 
            GetDay(SafeSubstring(input, DayRange)));
    }

    static CodiceFiscaleBirthDayPart GetYear(string input)
    {
        if (string.IsNullOrEmpty(input)) return new CodiceFiscaleBirthDayPart("invalid year");
        if (!int.TryParse(input, out var yearNum)) return new CodiceFiscaleBirthDayPart("year is not numeric");
        if (yearNum is < 0 or > 99) return new CodiceFiscaleBirthDayPart("year is not between 0 and 99");
        
        int year = yearNum <= (DateTime.UtcNow.Year - 2000) ? 2000 + yearNum : 1900 + yearNum;
        return new CodiceFiscaleBirthDayPart(year);
    }
    
    static CodiceFiscaleBirthDayPart GetMonth(string input)
    {
        if (string.IsNullOrEmpty(input)) return new CodiceFiscaleBirthDayPart("invalid month");
        int? month = char.ToUpper(input[0]) switch
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
        if (month == null) return new CodiceFiscaleBirthDayPart("invalid character in month");
        
        return new CodiceFiscaleBirthDayPart(month.Value);
    }
    
    static CodiceFiscaleBirthDayPart GetDay(string input)
    {
        if (string.IsNullOrEmpty(input)) return new CodiceFiscaleBirthDayPart("invalid day");

        if (!int.TryParse(input, out int day)) return new CodiceFiscaleBirthDayPart("invalid day part");
        if (day is > 0 and <= 31) return new CodiceFiscaleBirthDayPart(day);
        if (day is > 40 and <= 71) return new CodiceFiscaleBirthDayPart(day - 40);

        return new CodiceFiscaleBirthDayPart("invalid day part (not between 1 and 31 or 41 and 71)");
    }
    
    static string SafeSubstring(string input, Range range)
    {
        (int start, int length) = range.GetOffsetAndLength(input.Length);
        return input.Length >= start + length ? input[start..(start + length)] : string.Empty;
    }

    public DateTime? AsDateTime()
    {
        if (Year.IsError) return null;
        if (Month.IsError) return null;
        if (Day.IsError) return null;
        
        return new DateTime(Year.Value, Month.Value, Day.Value, 0, 0, 0, 0, DateTimeKind.Utc);
    }
}