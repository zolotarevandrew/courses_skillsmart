using System.Threading.Tasks;
using OOAP2.lesson8;
using OOAP2.lesson9;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {

            await Task.CompletedTask;
            Lesson9Program.Main(args);
        }
    }
}