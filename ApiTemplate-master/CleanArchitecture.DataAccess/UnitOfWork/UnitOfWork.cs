using CleanArchitecture.DataAccess.Contexts;
using CleanArchitecture.DataAccess.IRepository;
using CleanArchitecture.DataAccess.IUnitOfWorks;
using CleanArchitecture.DataAccess.Repsitory;

namespace CleanArchitecture.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.ContainsKey(type))
            {
                var repo = new Repository<T>(_context);
                _repositories[type] = repo;
            }

            return (IRepository<T>)_repositories[type];
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
