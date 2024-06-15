#define V2


using System;


public class Contract
{
    public string Name { get; set; }
#if V1
    public string V1Field { get;set; }
#elif V2
    public string V2Field { get;set; }
#else
        
#endif
}

public static class Test
{
    public static void TestV0()
    {
        var contract = new Contract
        {
            Name = "test"
        };
    }
    
    public static void TestV1()
    {
#if V1
        var contract = new Contract
        {
            Name = "test",
            V1Field = "v2"
        };
#endif
    }
    
    public static void TestV2()
    {
#if V2
        var contract = new Contract
        {
            Name = "test",
            V2Field = "v2"
        };
#endif
    }
}