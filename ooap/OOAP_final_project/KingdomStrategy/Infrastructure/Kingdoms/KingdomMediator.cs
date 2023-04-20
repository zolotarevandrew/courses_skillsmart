using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Kingdoms.Events;

namespace KingdomStrategy.Infrastructure.Kingdoms;

/// <summary>
/// kingdom scope mediator, will be used inside storage, to pass mediator objects into specific ADT
/// </summary>
public class KingdomMediatorFactory
{
    private readonly IMediator _mediator;
    public KingdomMediatorFactory(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public IMediator Get(KingdomRef @kingdomRef)
    {
        return new KingdomMediator(_mediator, @kingdomRef);
    }
    
    class KingdomMediator : IMediator
    {
        private readonly IMediator _mediator;
        private readonly KingdomRef _kingdomRef;

        public KingdomMediator(IMediator mediator, KingdomRef @kingdomRef)
        {
            _mediator = mediator;
            _kingdomRef = kingdomRef;
        }

        public Task Publish<TMessage>(TMessage message)
        {
            var kingdomEvent = new KingdomEvent
            {
                Kingdom = _kingdomRef,
                Payload = message
            };
            return _mediator.Publish(kingdomEvent);
        }
    }
}