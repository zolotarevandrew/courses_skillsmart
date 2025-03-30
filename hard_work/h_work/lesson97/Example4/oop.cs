namespace h_work.lesson97.Example4;

public class BoxedValue<T>(T value)
{
    private readonly T _value = value;

    public T Unwrap()
    {
        return _value;
    }
}