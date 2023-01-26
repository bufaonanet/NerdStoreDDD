namespace NerdStoreDDD.Core.Data;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
