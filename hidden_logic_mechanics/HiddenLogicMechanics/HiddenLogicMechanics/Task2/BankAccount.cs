using Xunit;

namespace HiddenLogicMechanics.Task2;

public class BankAccount( double balance )
{
    private double _balance = balance;

    public void Deposit( double amount )
    {
        _balance += amount;
    }
    
    public void Withdraw( double amount )
    {
        _balance -= amount;
    }
    
    public double Balance => _balance;
}

public class BankAccountTests
{
    public static void Run( )
    {
        NegativeBalance_Deposit_ShouldBePositive( );
        PositiveBalance_Deposit_ShouldBePositive( );
        PositiveBalance_Withdraw_ShouldBeNegative( );
        PositiveBalance_Withdraw_ShouldBePositive( );
        PositiveBalance_DepositBigValue_ShouldBeOk( );
        PositiveBalance_WithdrawBigValue_ShouldBeOk( );
    }

    static void NegativeBalance_Deposit_ShouldBePositive( )
    {
        // Arrange
        var account = new BankAccount( -1 );
        
        // Act
        account.Deposit( 20 );
        
        // Assert
        Assert.Equal(19f, account.Balance);
    }
    
    static void PositiveBalance_Deposit_ShouldBePositive( )
    {
        // Arrange
        var account = new BankAccount( 2 );
        
        // Act
        account.Deposit( 20 );
        
        // Assert
        Assert.Equal(22f, account.Balance);
    }
    
    static void PositiveBalance_Withdraw_ShouldBePositive( )
    {
        // Arrange
        var account = new BankAccount( 3 );
        
        // Act
        account.Withdraw( 2 );
        
        // Assert
        Assert.Equal(1f, account.Balance);
    }
    
    static void PositiveBalance_Withdraw_ShouldBeNegative( )
    {
        // Arrange
        var account = new BankAccount( 3 );
        
        // Act
        account.Withdraw( 20 );
        
        // Assert
        Assert.Equal(-17f, account.Balance);
    }
    
    static void PositiveBalance_DepositBigValue_ShouldBeOk( )
    {
        // Arrange
        var account = new BankAccount( 10000000f );
        
        // Act
        account.Deposit( double.MaxValue );
        
        // Assert
        Assert.True( account.Balance > 0 );
    }
    
    static void PositiveBalance_WithdrawBigValue_ShouldBeOk( )
    {
        // Arrange
        var account = new BankAccount( 10f );
        
        // Act
        account.Withdraw( double.MaxValue );
        
        // Assert
        Assert.True( account.Balance < 0 );
    }
}