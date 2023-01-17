using System;
using System.Threading.Tasks;

namespace OOAP2.lesson7
{
    public class SendResult
    {
        public bool Ok { get; set; }
        public string MessageId { get; set; }
    }
    
    public class SlackNotifier
    {
        public async Task<SendResult> Notify(string message)
        {
            await Task.CompletedTask;
            return new SendResult
            {
                Ok = true,
                MessageId = "slack"
            };
        }
    }

    public class TelegramNotifier
    {
        public async Task<SendResult> Notify(string message)
        {
            await Task.CompletedTask;
            return new SendResult
            {
                Ok = true,
                MessageId = "telegram"
            };
        }
    }

    public class RequestHandler
    {
        // В c# динамическое связывание доступно только через type dynamic
        // В данном случае, возлагаем на компилятор проверку, чтобы передавался правильный типа notifier-а, с методом и результатом
        public async Task Execute(dynamic notifier, string message)
        {
            SendResult result = await notifier.Notify(message);
            if (result.Ok)
            {
                Console.WriteLine(result.MessageId);
            }
        }
    }
    
    class Program
    {
        static async Task Main(string[] args)
        {
            var slackNotifier = new SlackNotifier();

            var telegramNotifier = new TelegramNotifier();

            var rqHandler = new RequestHandler();

            await rqHandler.Execute(slackNotifier, "new user added");
            await rqHandler.Execute(telegramNotifier, "new user added");
            
            //выведет
            
            //slack
            //telegram
        }
    }
}