using System;
using System.Threading.Tasks;

namespace OOAP2.lesson21;

//наследование реализации

public abstract class Notification
{
    public abstract Task Send(string message);
}

public class SlackNotification : Notification
{
    public override Task Send(string message)
    {
        Console.WriteLine("message sended to slack " + message);
        return Task.CompletedTask;
    }
}

public abstract class Alert : SlackNotification
{
    
}

public class DeployFailedAlert : Alert
{
    //наследуем реализацию слак нотификации, для более удобной отсылки Алертов
}

//льготное наследование
//P.S подсказал chat gpt:)

public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        // Log the message to a file
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
