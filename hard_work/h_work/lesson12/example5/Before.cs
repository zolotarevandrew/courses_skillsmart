namespace h_work.lesson12.example5;

public class Before
{
    public static bool ConvertAlert(string alertCode)
    {
        switch (alertCode)
        {
            case "NOT_FOUND": return true;
            default: return false;
        }
    }
}