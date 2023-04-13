namespace KingdomStrategy.Domain.Kingdoms.Ratings;


public class KingdomRating : Any
{
    public KingdomRating(KingdomRef @ref, int value, DateTime date)
    {
        Ref = @ref;
        Value = value;
        Date = date;
    }

    public KingdomRef Ref { get; init; }
    public int Value { get; init; }
    public DateTime Date { get; init; }

    public KingdomRating Add(KingdomRating other, DateTime date)
    {
        var res = other.Value + Value;
        return new KingdomRating(Ref, res, date);
    }
    
}