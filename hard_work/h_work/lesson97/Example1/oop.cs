namespace h_work.lesson97.Example1;

public interface ISumable<TSelf> where TSelf : ISumable<TSelf>
{
    static abstract TSelf operator +(TSelf left, TSelf right);
}

public readonly struct CustomNumber(int value) : ISumable<CustomNumber>
{
    public int Value { get; } = value;
    public static CustomNumber operator +(CustomNumber left, CustomNumber right) => new(left.Value + right.Value);
}

public class Test
{
    public void Run()
    {
        var number1 = new CustomNumber(1);
        var number2 = new CustomNumber(2);

        var number = number1 + number2;
    }
}