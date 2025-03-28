using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenaricRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task<IEnumerable<TEntity?>> GetAllAsync(bool asNoTracking = false);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
void Delete(TEntity entity);
    }
}
