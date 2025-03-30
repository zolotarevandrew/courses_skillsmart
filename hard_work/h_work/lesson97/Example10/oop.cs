

using Castle.Core.Configuration;

public enum ESmsPriority
{
    Low,
    High,
}

public interface ISmsSender
{
    Task SendAsync(string number, string message);
}
public class PrioritySender
{
    private readonly Dictionary<ESmsPriority, ISmsSender> _senders;

    public PrioritySender(IConfiguration config, IEnumerable<ISmsSender> senders)
    {
        var mapping = config.GetSection("SmsSenders").Get<Dictionary<string, string>>();
        _senders = new Dictionary<ESmsPriority, ISmsSender>
        {
            [ESmsPriority.Low] = senders.First(s => s.GetType().Name == mapping["Low"]),
            [ESmsPriority.High] = senders.First(s => s.GetType().Name == mapping["High"])
        };
    }

    public Task Send(ESmsPriority priority, string number, string message)
    {
        return _senders[priority].SendAsync(number, message);
    }
}