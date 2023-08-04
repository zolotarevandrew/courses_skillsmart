namespace h_work.lesson16.example1.Before;

public interface ITestOnboardingContext
{

}

public interface TestOnboardingStepContext
{

}

public class OnboardingPersonEntity
{

}

public enum ESourcePerson
{
    User,
    SearchDb
}

public class OnboardingPersonUpdateEntity
{

}

public interface IOnboardingPersonsService
{
    Task Add(ITestOnboardingContext context, OnboardingPersonEntity entity);

    Task<OnboardingPersonEntity> Add(ITestOnboardingContext context,
        string firstName, string lastName, ESourcePerson sourcePerson);

    Task<OnboardingPersonEntity> AddBeneficiary(ITestOnboardingContext context,
        string firstName, string lastName, ESourcePerson source = ESourcePerson.User);

    Task<OnboardingPersonEntity> AddRegistrator(ITestOnboardingContext context, TestOnboardingStepContext stepContext,
        string firstName, string lastName, bool manualAdding = false);

    Task<OnboardingPersonEntity> AddLegalRepresentative(ITestOnboardingContext context,
        string firstName, string lastName, ESourcePerson source = ESourcePerson.SearchDb,
        DateTime? birthday = null);

    Task Update(ITestOnboardingContext context, OnboardingPersonUpdateEntity updateEntity);
    Task Update(OnboardingPersonUpdateEntity updateEntity);
    Task SetPersonUserId(ITestOnboardingContext context, Guid personId, Guid userId);
    Task ChangePersonOnboardingId(ITestOnboardingContext context, Guid personId);

    Task SetRegistratorOnOnePerson(ITestOnboardingContext context, TestOnboardingStepContext stepContext, Guid personId,
        Guid userId, bool autoMarked);

    Task ClearRegistratorInfoFromPersons(ITestOnboardingContext context);
    Task SetBeneficiaryOnPersons(ITestOnboardingContext context, List<Guid> personIds);
    Task ClearBeneficiaryOnPersons(ITestOnboardingContext context);
    Task Delete(ITestOnboardingContext context, Guid personId);

    Task<OnboardingPersonEntity> Get(Guid personId);
    Task<OnboardingPersonEntity> GetRegistrator(ITestOnboardingContext context);
    Task<bool> IsLegalRepresentative(ITestOnboardingContext context, Guid personId);
    bool IsLegalRepresentative(ITestOnboardingContext context, OnboardingPersonEntity person);
    Task<bool> IsRegistrator(ITestOnboardingContext context, Guid personId);
    bool IsRegistrator(ITestOnboardingContext context, OnboardingPersonEntity person);
    Task<bool> IsBeneficiary(ITestOnboardingContext context, Guid personId);
    bool IsBeneficiary(ITestOnboardingContext context, OnboardingPersonEntity person);
    Task<OnboardingPersonEntity> GetByUserId(ITestOnboardingContext context);
    Task<List<OnboardingPersonEntity>> GetAllUserPersons(Guid userId);
    Task<List<OnboardingPersonEntity>> GetUbosAndLegalRepresentative(ITestOnboardingContext context);
    Task<List<OnboardingPersonEntity>> GetUbosAndRegistrator(ITestOnboardingContext context);

    /// <summary>
    /// Персоны, которые беники и не легалы одновременно.
    /// </summary>
    Task<List<OnboardingPersonEntity>> GetOnlyUbos(ITestOnboardingContext context);

    /// <summary>
    /// Все персоны, которые помечены как беники.
    /// </summary>
    Task<List<OnboardingPersonEntity>> GetAllUbos(ITestOnboardingContext context);

    Task<List<OnboardingPersonEntity>> GetOnlyLegalRepresentatives(ITestOnboardingContext context);
    Task<List<OnboardingPersonEntity>> GetByOnboarding(ITestOnboardingContext context);
    Task<OnboardingPersonEntity> GetByOnboarding(ITestOnboardingContext context, Guid personId);
    Task<List<OnboardingPersonEntity>> GetByUser(Guid userId);
    Task<OnboardingPersonEntity> GetByUser(ITestOnboardingContext context, Guid userId);
    Task<List<OnboardingPersonEntity>> GetByOnboardings(IEnumerable<ITestOnboardingContext> contexts);
    Task<List<OnboardingPersonEntity>> GetByOnboarding(ITestOnboardingContext context, bool includeDeleted);
}