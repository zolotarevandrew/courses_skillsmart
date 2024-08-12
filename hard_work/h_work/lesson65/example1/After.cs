namespace h_work.lesson65.example1;

public record OnboardingPersonV2
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public Email? Email { get; init; }
    public MobilePhone? Phone { get; init; }
    

    public (OnboardingPersonV2 Person, bool Changed) ChangePhone(string code, string number)
    {
        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(number))
        {
            var newRes = this with
            {
                Phone = new MobilePhone(code, number)
            };
            return (newRes, true);
        }

        return (this, false);
    }

    public (OnboardingPersonV2 Person, bool Changed) ChangeEmail(string email)
    {
        if (!string.IsNullOrEmpty(email))
        {
            var newRes = this with
            {
                Email = new Email(email)
            };
            return (newRes, true);
        }
        
        return (this, false);
    }
}