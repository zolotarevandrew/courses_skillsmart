namespace KingdomStrategy.Infrastructure;

public interface IMessageHandler<TMessage>
{
    Task Handle(TMessage message, CancellationToken cancellationToken = default);
}

public interface IPublisher
{
    Task Publish<TMessage>(TMessage message);
}
public class MessagePublisher : IPublisher
{
    private readonly IServiceProvider _provider;

    public MessagePublisher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task Publish<TMessage>(TMessage message)
    {
        var messageHandler = _provider.GetRequiredService<IMessageHandler<TMessage>>();
        var task = Task.Run(() => messageHandler.Handle(message, CancellationToken.None));
    }
}