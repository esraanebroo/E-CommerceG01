using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IGenaricRepository<TEntity, Tkey> GenaricRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
