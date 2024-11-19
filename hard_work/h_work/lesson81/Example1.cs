namespace h_work.lesson81;

/*
public record FinomPersonVerificationGroup(
    List<FinomPersonVerification> Items,
    Guid? RegistratorPersonId)
{
    public FinomPersonVerification Registrator => Items.FirstOrDefault(x => x.Person.Id == RegistratorPersonId);
    public List<FinomPersonVerification> WithoutRegistratorItems => Items.Where(x => x.Person.Id != RegistratorPersonId).ToList();

}
*/