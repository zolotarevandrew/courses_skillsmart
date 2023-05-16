using System.Text;
using SharpFuzz;

namespace FuzzTestingTemplate
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        switch (args[0])
			{
				case "TestFunc": Fuzzer.LibFuzzer.Run(Test); return;
				default: throw new ArgumentException($"Unknown fuzzing function: {args[0]}");
			}
        }
        
        public static void Test(ReadOnlySpan<byte> span)
        {
	        var bytes = span.ToArray();
	        var str = Encoding.UTF8.GetString(bytes);
	        if (str.Contains("123")) throw new InvalidOperationException("hahaa");
        }
    }
}