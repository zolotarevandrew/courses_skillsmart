using System;
using System.Threading.Tasks;
using OOAP2.lesson7;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var slackNotifier = new SlackNotifier();

            var telegramNotifier = new TelegramNotifier();

            var rqHandler = new RequestHandler();

            await rqHandler.Execute(slackNotifier, "new user added");
            await rqHandler.Execute(telegramNotifier, "new user added");
        }
    }
}