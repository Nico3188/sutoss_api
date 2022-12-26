using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Repositories.Base.Interfaces
{
    public interface IRepository<TEntity>
    {
        public DbContext GetContext();
        public IDbContextTransaction BeginTransaction();
        public Task<IQueryable<TEntity>> Get<TInput>(TInput id);
        public Task<IQueryable<TEntity>> All();
        public Task<TEntity> Insert(TEntity entity);
        public Task<TEntity> Update(TEntity entity);
        public Task Delete<TInput>(TInput id);
        public Task SaveChanges();
        public Task<bool> Any();
    }
}
