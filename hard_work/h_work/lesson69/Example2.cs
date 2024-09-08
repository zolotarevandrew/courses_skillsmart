namespace h_work.lesson69;

public enum EReviewRejectType
{
    Final,
    Retry
}

public class ReviewRejectType
{
    public EReviewRejectType Value { get; }

    public ReviewRejectType(string type)
    {
        Value = Convert(type);
    }

    EReviewRejectType Convert(string type)
    {
        if (type == "FINAL") return EReviewRejectType.Final;
        if (type == "RETRY") return EReviewRejectType.Retry;
        throw new ArgumentOutOfRangeException(nameof(type));
    }
}