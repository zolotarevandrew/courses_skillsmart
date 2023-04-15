namespace KingdomStrategy.Infrastructure;

public interface IMessageHandler<TMessage>
{
    Task Handle(TMessage message, CancellationToken cancellationToken = default);
}

public interface IMediator
{
    Task Publish<TMessage>(TMessage message);
}
public class MessageMediator : IMediator
{
    private readonly IServiceProvider _provider;

    public MessageMediator(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task Publish<TMessage>(TMessage message)
    {
        var messageHandler = _provider.GetRequiredService<IMessageHandler<TMessage>>();
        var task = Task.Run(() => messageHandler.Handle(message, CancellationToken.None));
    }
}