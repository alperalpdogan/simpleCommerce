using Microsoft.EntityFrameworkCore;
using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Data.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _entities;
        private readonly SimComDbContext _dbContext;

        public EfRepository(SimComDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _entities;

        public IQueryable<TEntity> TableAsNoTracking => _entities.AsNoTracking();

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _entities.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(id)} must be a positive integer");

            var entity = await _entities.SingleOrDefaultAsync(entity => entity.Id == id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with id: {id} not found");

            _entities.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            var entities = _entities.Where(entity => ids.Contains(entity.Id));

            _entities.RemoveRange(entities);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(id)} must be a positive integer");

            return await _entities.SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<int> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids));

            return await _entities
                .Where(entity => ids.Contains(entity.Id))
                .ToListAsync();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task InsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _entities.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _entities.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
