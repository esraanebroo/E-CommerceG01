
namespace Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        //private Dictionary<string, object> _repositories;
        private ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new();
        }
        public IGenaricRepository<TEntity, Tkey> GenaricRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
            => (IGenaricRepository<TEntity, Tkey>)_repositories.GetOrAdd(typeof(TEntity).Name, (_) => new GenericRepository<TEntity, Tkey>(_dbContext));

       

        public async Task<int> SaveChangesAsync()=>await _dbContext.SaveChangesAsync();
        
    }
}
