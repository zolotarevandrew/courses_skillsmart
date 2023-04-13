using System.Numerics;

namespace KingdomStrategy.Domain.Kingdoms;

public class KingdomRef : IEqualityOperators<KingdomRef, KingdomRef, bool>
{
    public KingdomRef(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; init; }
    public string Name { get; init; }
    
    public static bool operator ==(KingdomRef? left, KingdomRef? right)
    {
        return left.Id == right.Id;
    }

    public static bool operator !=(KingdomRef? left, KingdomRef? right)
    {
        return left.Id != right.Id;
    }
}