namespace h_work.lesson12.example4;

public class UserV2
{
    public UserV2(Guid id, string password, string email)
    {
        Id = id;
        Email = email ?? throw new ArgumentNullException("email");
        Password = password ?? throw new ArgumentNullException("password");
    }
    
    public Guid Id { get; }
    public string Password { get;}
    public string Email { get; }
}