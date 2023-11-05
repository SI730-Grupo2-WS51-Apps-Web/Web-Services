namespace Akira.API.Akira.Domain.Repositories;
public interface IUnitOfWork
{
    Task CompleteAsync();
}