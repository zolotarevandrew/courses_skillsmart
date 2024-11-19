namespace h_work.lesson81;

/*
public class Example3
{
  enum CheckPersonListType
    {
        Duplicate,
        DuplicateWithSameOnboarding
    }
    private async Task<Dictionary<CheckPersonListType, List<OnboardingPerson>>> CheckSameType(IBankOnboardingContext context, FinomPersonVerificationDuplicate duplicate)
    {
        var res = new Dictionary<CheckPersonListType, List<OnboardingPerson>>();
        res[CheckPersonListType.Duplicate] = new List<OnboardingPerson>();
        res[CheckPersonListType.DuplicateWithSameOnboarding] = new List<OnboardingPerson>();
        
        foreach (var person in duplicate.Persons)
        {
            var onboardingPerson = await _persons.GetById(person.PersonId);
            if (onboardingPerson is null) continue;

            var dupContext = await _onboardingContext.GetById(onboardingPerson.OnboardingId);
            if (dupContext?.OnboardingType == context.OnboardingType)
            {
                res[CheckPersonListType.DuplicateWithSameOnboarding].Add(onboardingPerson);
                continue;
            }
            
            res[CheckPersonListType.Duplicate].Add(onboardingPerson);
            
        }

        return res;
    }   
}
*/