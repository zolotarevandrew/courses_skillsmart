using System.Globalization;

namespace HiddenLogicMechanics.Task8;

public class DateExample
{
    /*
     * 1 - Передаем таймзону, непонятно в какой таймзоне находится это время.
     * 2 - Парсим через Try
     * 3 - Передаем Culture
     * 4 - Используем DateTimeOffset, можем получить и локальное и UTC время.
     */
    public static void Main()
    {
        string dateString = "2024-05-13 14:30:00";
        TimeZoneInfo moscowZone = TimeZoneInfo.FindSystemTimeZoneById( "Europe/Moscow" );
        string format = "yyyy-MM-dd HH:mm:ss";
        var culture = CultureInfo.InvariantCulture;

        if ( DateTime.TryParseExact( dateString, format, culture, DateTimeStyles.None, out DateTime localTime ) )
        {
            DateTimeOffset moscowOffset = new DateTimeOffset( localTime, moscowZone.GetUtcOffset( localTime ) );
            DateTime local = localTime;
            DateTime utc = moscowOffset.UtcDateTime;
        }
    }
}