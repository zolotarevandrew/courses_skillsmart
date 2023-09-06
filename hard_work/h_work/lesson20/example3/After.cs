namespace h_work.lesson20.example3;


public class Money
{
    public decimal Value { get; }
    public Money(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidOperationException("Invalid amount");
        Value = amount;
    }
}
public class BankAccountV2
{
    public string AccountNumber { get; }
    public decimal Balance { get; }

    private BankAccountV2(string accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public BankAccountV2 Deposit(Money money)
    {
        return new BankAccountV2(AccountNumber, Balance + money.Value);
    }

    public BankAccountV2 Withdraw(Money amount)
    {
        if (amount.Value > Balance)
            return new BankAccountV2(AccountNumber, Balance);

        return new BankAccountV2(AccountNumber, Balance - amount.Value);
    }
}