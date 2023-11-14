using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Coasia.WebApiRestful.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Coasia.WebApiRestful.Data.Infratructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        NetCoreDbcontext _netCoreDbcontext;
        public RepositoryBase(NetCoreDbcontext netCoreDbcontext)
        {
            _netCoreDbcontext = netCoreDbcontext;
        }

        public IQueryable<T> Table => _netCoreDbcontext.Set<T>();

        public async Task CommitAsync()
        {
            await _netCoreDbcontext.SaveChangesAsync();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entitys = _netCoreDbcontext.Set<T>().Where(expression).ToList();
            if (entitys.Count > 0)
            {
                _netCoreDbcontext.Set<T>().RemoveRange(entitys);
            }
        }

        public void Delete(T entity)
        {
            EntityEntry entityEntry = _netCoreDbcontext.Entry(entity);
            entityEntry.State = EntityState.Deleted;

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _netCoreDbcontext.Set<T>().ToListAsync();
            }
            else
            {
                return await _netCoreDbcontext.Set<T>().Where(expression).ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _netCoreDbcontext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _netCoreDbcontext.Set<T>().FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _netCoreDbcontext.AddAsync(entity);
        }

        public async Task InsertAsync(IEnumerable<T> entities)
        {
            await _netCoreDbcontext.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _netCoreDbcontext.Entry(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
