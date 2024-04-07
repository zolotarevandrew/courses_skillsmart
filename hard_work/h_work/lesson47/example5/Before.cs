namespace h_work.lesson47.example5;

/*
public class Before
{
  private async Task<List<(Guid companyId, EBankCode bankCode)>> GetCompanies(RelatedDocument document)
    {
        Guid[] companyIds = document.Relation.Type switch
        {
            EDocumentRelationType.Company => new[] { document.Relation.Id },
            EDocumentRelationType.Person => await GetCompanyIdsByPersonId(document.Relation.Id),
            EDocumentRelationType.Questionnaire => await GetCompanyIdsByInitiator(document.Initiator.Id),
            _ => throw new NotSupportedException(document.Relation.Type.ToString())
        };

        var result = new List<(Guid companyId, EBankCode bankCode)>();

        foreach (var companyId in companyIds)
        {
            var bankCode = await GetCompanyBankCode(companyId);
            result.Add((companyId, bankCode));
        }

        return result;
    }

    private async Task<Guid[]> GetCompanyIdsByInitiator(Guid id)
    {
        var context = await _bankOnboardingContextService.TryGetLastByUserId(id);
        return new[] { context.CompanyId };
    }

    private async Task<EBankCode> GetCompanyBankCode(Guid companyId)
    {
        var context = await _bankOnboardingContextService.TryGetLast(companyId);
        return context.BankCode;
    }

    private async Task<Guid[]> GetCompanyIdsByPersonId(Guid personId)
    {
        var person = await _bankOnboardingPersonsService.Get(personId);
        var context = await _bankOnboardingContextService.GetById(person.OnboardingId);
        return new[] { context.CompanyId };
    }
}
*/