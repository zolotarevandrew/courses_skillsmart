namespace h_work.lesson62;

public class Example5
{
    /*
    private static IReadOnlyCollection<Guid> Before(ThroughSoloCompaniesIterator iterator)
    {
        var list = new List<Guid>();
        do
        {
            list.AddRange(iterator.GetPersons().Select(x => x.LegalRepresentativeId));
        } while (iterator.MoveNext());
        return list;
    }
    */
    
    /*
    private static IReadOnlyCollection<Guid> After(ThroughSoloCompaniesIterator iterator)
    {
        var list = iterator
            .SelectMany(iter => iter.GetPersons())
            .Select(person => person.LegalRepresentativeId)
            .ToList();
    }
    */
    }