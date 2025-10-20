using Xunit;

namespace HiddenLogicMechanics.Task3;

public class BankAccount( AccountBalance balance )
{
    private AccountBalance _balance = balance;

    public void Deposit( AccountBalance amount )
    {
        _balance += amount;
    }
    
    public bool Withdraw( AccountBalance amount )
    {
        ( bool isValid, AccountBalance? newBalance ) = _balance.Minus( amount );
        if ( !isValid ) return false;

        _balance = newBalance!.Value;
        return true;
    }
    
    public AccountBalance Balance => _balance;
}

public readonly struct AccountBalance
{
    public double Value { get; }

    private AccountBalance( double value )
    {
        Value = value;
    }

    public static (bool IsValid, AccountBalance? Balance ) Create( double value )
    {
        if ( value < 0 )
        {
            return ( false, null );
        }

        return ( true, new AccountBalance( value ) );
    }

    public static AccountBalance operator +( AccountBalance left, AccountBalance right ) => new AccountBalance( left.Value + right.Value );
    
    public (bool IsValid, AccountBalance? Balance ) Minus( AccountBalance value )
    {
        double res = Value - value.Value;
        return Create( res );
    }
}

public class BankAccountTests
{
    public static void Run( )
    {
        PositiveBalance_Deposit_ShouldBePositive( );
        PositiveBalance_Withdraw_ShouldBePositive( );
        PositiveBalance_Withdraw_ShouldBeFalse( );
    }

    static void PositiveBalance_Deposit_ShouldBePositive( )
    {
        // Arrange
        (bool IsValid, AccountBalance? Balance) balance = AccountBalance.Create( 0 );
        BankAccount account = new BankAccount( balance.Balance!.Value );
        
        // Act
        (bool IsValid, AccountBalance? Balance) deposit = AccountBalance.Create( 19 );
        account.Deposit( deposit.Balance!.Value );
        
        // Assert
        Assert.Equal( 19f, account.Balance.Value );
    }
    
    static void PositiveBalance_Withdraw_ShouldBePositive( )
    {
        // Arrange
        (bool IsValid, AccountBalance? Balance) balance = AccountBalance.Create( 3 );
        var account = new BankAccount( balance.Balance!.Value );
        
        // Act
        (bool IsValid, AccountBalance? Balance) withdraw = AccountBalance.Create( 2 );
        var res = account.Withdraw( withdraw.Balance!.Value );
        
        // Assert
        Assert.True( res );
        Assert.Equal( 1f, account.Balance.Value );
    }
    
    static void PositiveBalance_Withdraw_ShouldBeFalse( )
    {
        // Arrange
        (bool IsValid, AccountBalance? Balance) balance = AccountBalance.Create( 3 );
        var account = new BankAccount( balance.Balance!.Value );
        
        // Act
        (bool IsValid, AccountBalance? Balance) withdraw = AccountBalance.Create( 20 );
        var res = account.Withdraw( withdraw.Balance!.Value );
        
        // Assert
        Assert.False( res );
        Assert.Equal( 3f, account.Balance.Value );
    }
}