using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOAP2.lesson16;

public interface IConsumer<T>
{
    Task ProcessBatchAsync(IEnumerable<T> data);
}

public class RabbitConsumer<T> : IConsumer<T>
{
    public Task ProcessBatchAsync(IEnumerable<T> data)
    {
        return Task.CompletedTask;
    }
}

public class InMemoryConsumer<T> : IConsumer<T>
{
    public Task ProcessBatchAsync(IEnumerable<T> data)
    {
        return Task.CompletedTask;
    }
}

public class Event {}
public class UserEvent : Event {}


public static class Lesson16Program
{
    public static void Main(string[] args)
    {
        //x = y
        IConsumer<Event> consumer = new RabbitConsumer<Event>();
        
        //ienumerable ковариантный интерфейс
        consumer.ProcessBatchAsync(new List<Event>());
        
        //x.foo(z)
        consumer.ProcessBatchAsync(new List<UserEvent>());
    }
}
    

