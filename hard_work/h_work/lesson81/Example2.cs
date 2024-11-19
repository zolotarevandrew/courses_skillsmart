namespace h_work.lesson81;

/*
public class Example2
{
    private async Task<IReadOnlyCollection<CddExportCddParameter>> BuildPersons()
    {
        (List<CompanyPersonInStorage> LegalReps, List<CompanyPersonInStorage> OtherPersons) GetPersons()
        {
            return
                (Context.Persons.Where(x => x.IsLegalRepresentative is true).ToList(),
                    Context.Persons.Where(x => x.IsLegalRepresentative is not true).ToList()
                );
        }

        var persons = GetPersons();
        var result = new List<CddParameterInfo>();
        foreach (var person in persons.LegalReps)
        {
            //map logic
        }
        
        foreach (var person in persons.OtherPersons)
        {
            //map logic
        }

        return result.Select(Map).ToList();
    }   
}
*/