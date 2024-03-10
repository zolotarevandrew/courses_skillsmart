namespace h_work.lesson43.example1;

public enum EVerificationListType
{
    Selectable,
    Strict
}

public class Person
{
    public Guid Id { get; set; }
}

public class PersonVerification
{
    public bool IsSuccess { get; set; }
    public bool IsFraud { get; set; }
    public bool IsFailed { get; set; }
    public bool IsPending { get; set; }
    public bool IsPossibleRetry { get; set; }
    public Person Person { get; set; }

    public bool IsLinkShared()
    {
        throw new NotImplementedException();
    }
}

public record PersonVerificationGroup(
    List<PersonVerification> Items,
    EVerificationListType ListType,
    Guid? RegistratorPersonId)
{
    public PersonVerification Registrator => Items.FirstOrDefault(x => x.Person.Id == RegistratorPersonId);
    public List<PersonVerification> WithoutRegistratorItems => Items.Where(x => x.Person.Id != RegistratorPersonId).ToList();
    public PersonVerification NonRegistratorWithReverification => WithoutRegistratorItems.FirstOrDefault(x => x.IsPossibleRetry);


    public bool HasOnlyRegistrator => Registrator != null && WithoutRegistratorItems.Count == 0;

    public bool IsRegistratorSharedLinks
    {
        get
        {
            if (Registrator is null) return false;
            bool isRegistratorFinished = Registrator.IsSuccess || Registrator.IsPending;
            if (!isRegistratorFinished) return false;
            if (HasOnlyRegistrator) return true;

            if (ListType == EVerificationListType.Selectable) return WithoutRegistratorItems.Any(it => it.IsLinkShared());
            if (ListType == EVerificationListType.Strict) return WithoutRegistratorItems.All(it => it.IsLinkShared());

            throw new NotImplementedException("Unknown list type " + ListType);
        }
    }

    public bool IsFraud => Items.Any(v => v.IsFraud);
    public bool IsFailed => Items.Any(v => v.IsFailed);

    public bool IsSuccess
    {
        get
        {
            if (ListType == EVerificationListType.Selectable)
            {
                if (Registrator.IsSuccess && HasOnlyRegistrator) return true;

                return Registrator.IsSuccess && WithoutRegistratorItems.Any(it => it.IsSuccess);
            }

            if (ListType == EVerificationListType.Strict)
            {
                return Registrator.IsSuccess && WithoutRegistratorItems.All(it => it.IsSuccess);
            }

            throw new NotImplementedException("Unknown list type " + ListType);
        }
    }

    public bool IsCompleted => IsFailed || IsFraud || IsSuccess;
}