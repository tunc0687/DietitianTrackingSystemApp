﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DietitianTrackingSystemApp.Data.Domain.EfCoreRepository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
      where TEntity : class, new()
    {
        private readonly DbContext _context;
        public readonly DbSet<TEntity> _collection;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _collection = context.Set<TEntity>();

        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).SingleOrDefaultAsync();
        }

        public async Task<TEntity?> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>()
            .Where(expression)
            .AsNoTracking()
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindListAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            else
                return await _context.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Update(TEntity entity, params string[] propertyNames)
        {
            foreach (string propertyName in propertyNames)
            {
                _context.Set<TEntity>().Update(entity).Property(propertyName).IsModified = true;
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<(List<TEntity> Data, long TotalCount)> SearchAsync(IQueryable<TEntity> query, int? pageNumber, int? pageSize)
        {
            long totalItemCount = await query.CountAsync();

            if (pageSize.HasValue && pageSize > 0)
            {
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return (await query.AsNoTracking().ToListAsync(), totalItemCount);
        }
    }
}