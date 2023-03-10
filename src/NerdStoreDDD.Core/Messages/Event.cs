using MediatR;

namespace NerdStoreDDD.Core.Messages;

public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; set; }

    public Event()
    {
        Timestamp = DateTime.Now;
    }
}
