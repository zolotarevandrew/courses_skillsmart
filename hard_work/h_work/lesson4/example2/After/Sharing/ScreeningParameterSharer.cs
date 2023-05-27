using h_work.lesson4.example2.After.Parameters;

namespace h_work.lesson4.example2.After.Sharing;

public interface IScreeningParameterSharer
{
    Task ShareBetweenSameType(ScreeningParameter parameter, ScreenResult screenResult);
}

public class ScreeningParameterSharer : IScreeningParameterSharer
{
    public async Task ShareBetweenSameType(ScreeningParameter parameter, ScreenResult screenResult)
    {
        //sharing to db here instead of separate method
        //Task<AddSharedDataResult> AddScreeningPersonData(Guid id, string s, EParameterType personFullName, object o, object? screened);
    }
}