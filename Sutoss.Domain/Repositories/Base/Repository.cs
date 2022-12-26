using Sutoss.Domain.Services.Domain.Repositories.Base.Interfaces;
using Sutoss.Domain.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public SutossContext Context { get; set; }
        public DbSet<TEntity> DataSet { get; set; }
        private string SoftDeleteFieldName => "Deleted";

        public Repository(SutossContext context)
        {
            Context = context;
        }

        public DbContext GetContext()
        {
            return Context;
        }

        protected abstract string PredicateStringGet<TInput>(TInput id);
        protected abstract string PredicateStringAll();
        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public async Task<IQueryable<TEntity>> Get<TInput>(TInput id)
        {
            return await Task.Run(() =>
            {
                return DataSet.AsQueryable().Where(PredicateStringGet(id));
            });
        }

        public async Task<IQueryable<TEntity>> All()
        {
            return await Task.Run(() =>
            {
                var predicate = PredicateStringAll();
                if (string.IsNullOrEmpty(predicate))
                {
                    return DataSet.AsQueryable();
                }
                return DataSet.AsQueryable().Where(predicate);
            });
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await DataSet.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            DataSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public async Task Delete<TInput>(TInput id)
        {
            var entity = (await Get(id)).FirstOrDefault();

            if (entity == null)
            {
                throw new NotFoundException();
            }

            var softDeleted = false;

            if (!string.IsNullOrEmpty(SoftDeleteFieldName))
            {
                var softDeleteProperty = entity.GetType().GetProperty(SoftDeleteFieldName);

                if (softDeleteProperty != null)
                {
                    softDeleted = true;
                    if (softDeleteProperty.PropertyType == typeof(bool))
                    {
                        softDeleteProperty.SetValue(entity, true, null);
                    }

                    await Update(entity);
                }
            }

            if (!softDeleted)
            {
                DataSet.Remove(entity);
            }

            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            try
            {
                Context.ChangeTracker.DetectChanges();
                await Context.SaveChangesAsync();
            }
            catch
            {
                var changedEntries = Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted).ToList();

                foreach (var entry in changedEntries)
                {
                    entry.State = EntityState.Detached;
                }

                throw;
            }
        }

        public async Task<bool> Any()
        {
            return await Task.Run(() =>
            {
                var records = DataSet.Any();
                return records;
            });
        }
    }
}
