namespace h_work.lesson100;

public class Example3 
{
    public void ChangeName(string name, DateTime? changeAt = null)
    {
        var timestamp = changeAt ?? DateTime.UtcNow;
        //some logic
    }
}
