using h_work.lesson92.Example1;

namespace h_work.lesson92.Example2;

public readonly struct TransactionGroup : IGroup<CustomTransaction>
{
    public CustomTransaction Combine(CustomTransaction left, CustomTransaction right) => left + right;
    
    public CustomTransaction Inverse(CustomTransaction transaction) => transaction.Inverse();
    public CustomTransaction Zero => CustomTransaction.Empty;
}

public enum CustomTransactionType { Deposit, Withdraw }

public record CustomTransaction(CustomTransactionType Type, decimal Amount)
{
    public CustomTransaction Inverse() => this with { Type = Type == CustomTransactionType.Deposit ? CustomTransactionType.Withdraw : CustomTransactionType.Deposit };
    public static CustomTransaction Empty => new(CustomTransactionType.Deposit, 0m);

    decimal RealAmount() => Type == CustomTransactionType.Deposit ? Amount : -Amount;
    
    public static CustomTransaction operator +(CustomTransaction left, CustomTransaction right)
    {
        decimal total = left.RealAmount() + right.RealAmount();
        return total >= 0
            ? new CustomTransaction(CustomTransactionType.Deposit, total)
            : new CustomTransaction(CustomTransactionType.Withdraw, -total);
    }
}

public interface IGroup<T> : IMonoid<T>
{
    T Inverse(T item);
}

public static class GroupExtensions
{
    public static T InverseFold<T, G>(IEnumerable<T> collection, G group)
        where G : struct, IGroup<T>
    {
        var result = group.Zero;
        foreach (var item in collection)
        {
            result = group.Combine(result, group.Inverse(item));
        }

        return result;
    }
}

public class Example1
{
    static void Main()
    {
        var transactions = new List<CustomTransaction>
        {
            new(CustomTransactionType.Deposit, 100m),   
            new(CustomTransactionType.Withdraw, 50m),   
            new(CustomTransactionType.Deposit, 25m),   
            new(CustomTransactionType.Withdraw, 80m)   
        };
        CustomTransaction undoBalance = GroupExtensions.InverseFold(transactions.Skip(1), new TransactionGroup());

        Console.WriteLine(undoBalance);
    }
}

