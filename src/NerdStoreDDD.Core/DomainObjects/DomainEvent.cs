using NerdStoreDDD.Core.Messages;

namespace NerdStoreDDD.Core.DomainObjects;

public class DomainEvent : Event
{
    public DomainEvent(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }
}
