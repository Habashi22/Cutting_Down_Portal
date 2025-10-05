using CleanArchitecture.DataAccess.IRepository;
using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.DataAccess.Repsitory;


namespace CleanArchitecture.DataAccess.IUnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        Task<int> SaveAsync();
    }
}
