namespace h_work.lesson61;



public static class Example61_2
{
    public static T Fmin<T>(T a, T b)
        where T : IComparable<T>
    {
        return a.CompareTo(b) <= 0 ? a : b;
    }

    public static void Test()
    {
        string strMin = Fmin("1", "2");
        int intMin = Fmin(1, 2);
        // not compile object min = Fmin(1, "2");
        
        
    }
} 