namespace h_work.lesson33;


public sealed record User
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

public static class UserExtensions
{
    private static readonly Dictionary<string, object> Metadata = new();

    public static ThrottlingSettings? ThrottlingSettings(this User user)
    {
        var key = user.Id + "ThrottlingSettings";
        return Metadata.TryGetValue(key, out var value)
            ? (ThrottlingSettings)value
            : null;
    }
    
    public static void ChangeThrottlingSettings(this User user, ThrottlingSettings settings)
    {
        var key = user.Id + "ThrottlingSettings";
        Metadata[key] = settings;
    }
}

public class ThrottlingSettings
{
    public int MaxLoginAttemptsPerMinute { get; init; }
}