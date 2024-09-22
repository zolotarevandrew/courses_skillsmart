using h_work.lesson16.example1.After;

namespace h_work.lesson71.Example4;

public interface IOnboardingPersonById
{
    Task<OnboardingPerson> Get(Guid id);
}

public interface IOnboardingPersonsByOnboardingId
{
    Task<IEnumerable<OnboardingPerson>> Get(Guid onboardingId);
}

public interface IOnboardingPersonsByIds
{
    Task<IEnumerable<OnboardingPerson>> Get(Guid[] ids);
}

public interface IOnboardingPersonСreator
{
    Task<OnboardingPerson> TryCreate(CreateOnboardingPerson request);
}

public interface IOnboardingPersonRepresentationChanger
{
    Task<IEnumerable<OnboardingPerson>> Change(OnboardingPerson person, ChangeOnboardingPersonRepresentation representation);
}

public interface IOnboardingPersonContactsChanger
{
    //тут контакты менялись напрямую в OnboardingPerson, перезаписываясь
    //здесь как раз нужна иммутабельность, а в интерфейсе обьявляем явно 
    Task<OnboardingPerson> Change(OnboardingPerson person, (Email Email, MobilePhone Phone) сontacts);
}


