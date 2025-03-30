public interface IAccountManagerClient
{
    Task<AccountManager?> GetById(long id);
}

public class AccountManager(string Name);