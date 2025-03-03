namespace h_work.lesson94.Example1;

public class Before
{
    /*
     *  private async Task<(Guid UserId, OnboardingPerson Person)> GetSignerUserIdAndPersonId(
        IBankOnboardingContext context,
        Guid? personId)
    {
        var person = personId is null
            ? await _registratorService.GetByOnboarding(context.OnboardingId)
            : await _personsService.GetById(personId.Value);

        if (person is null) throw new Exception($"Person {personId} not found");

        var userId = person.UserId ?? await GetTempUserId(context, person);
        return (userId, person);
    }
    
     private async Task<Guid> GetTempUserId(IBankOnboardingContext context, OnboardingPerson person)
    {
        var tempAccessContext = await _personTempAccessService.GetByPerson(context, person.Id);
        if (tempAccessContext is null) throw new Exception($"No temp access for person {person.Id}");
        return tempAccessContext.TempUserId;
    }
     */
}