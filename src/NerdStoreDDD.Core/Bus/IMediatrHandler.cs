using NerdStoreDDD.Core.Messages;

namespace NerdStoreDDD.Core.Bus;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}
