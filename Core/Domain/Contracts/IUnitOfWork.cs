using Domain.Entites;
namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
       
        IGenaricRepository<TEntity, Tkey>   GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
        Task<int> SaveChangesAsync();
    }
}
