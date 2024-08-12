namespace h_work.lesson65.example1;

public record Email(string Value);
public record MobilePhone(string Code, string Number);

public class OnboardingPerson
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public Email? Email { get; private set; }
    public MobilePhone? Phone { get; private set; }
    

    public void ChangePhone(string code, string number)
    {
        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(number))
        {
            Phone = new MobilePhone(code, number);
        }
    }

    public void ChangeEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            Email = new Email(email);
        }
    }
}