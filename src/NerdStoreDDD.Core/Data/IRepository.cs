using NerdStoreDDD.Core.DomainObjects;

namespace NerdStoreDDD.Core.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; } 
}