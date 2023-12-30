namespace h_work.lesson32.example1;

public class LegalEntityGroup
{
    private readonly Dictionary<Guid, LegalEntity> _source;
    public LegalEntityGroup(IEnumerable<LegalEntity> source)
    {
        _source = source.ToDictionary( c => c.Id, c => c);
        IsEmpty = !_source.Any();
        Ids = _source.Keys.ToArray();
    }

    public bool IsEmpty { get; }
    public Guid[] Ids { get; }

    public LegalEntityGroup DirectlyOwnedBy(Guid[] ownerIds)
    {
        var filtered = _source.Values
            .Where(legalEntity => ownerIds.Any(owned => legalEntity.ManagedBusinesses.ContainsKey(owned)));
        return new LegalEntityGroup(filtered);
    }
}

public record LegalEntityLevel(byte Value)
{
    public LegalEntityLevel Next() => new((byte)(Value + 1));
}

public class LegalEntityHierarchy
{
    private const byte StartLevel = 1;
    private LegalEntityHierarchy(LegalEntityGroup source, LegalEntityLevel level)
    {
        Source = source;
        Level = level;
    }

    public LegalEntityHierarchy(LegalEntity company)
    {
        Level = new LegalEntityLevel(StartLevel);
        Source = new LegalEntityGroup(new[]
        {
            company
        });
    }

    public LegalEntityLevel Level { get; }
    public LegalEntityGroup Source { get; }

    public LegalEntityHierarchy? Next(LegalEntityGroup legalEntityGroup)
    {
        var ownerIds = Source.Ids;
        var nextLevelSource = legalEntityGroup.DirectlyOwnedBy(ownerIds);
        return nextLevelSource.IsEmpty 
            ? null 
            : new LegalEntityHierarchy(nextLevelSource, Level.Next());
    }
}

public static class Example
{
    public static void Test()
    {
        var company = new LegalEntity();
        var legalEntityHierarchy = new LegalEntityHierarchy(company);
        
        var legalEntityGroup = new LegalEntityGroup(new LegalEntity[] {});
        var nextLevelLegalEntities = legalEntityHierarchy.Next(legalEntityGroup);
        if (nextLevelLegalEntities == null)
        {
            return;
        }
    }
}

