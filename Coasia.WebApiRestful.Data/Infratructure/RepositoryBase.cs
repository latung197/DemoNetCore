using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Data.Infratructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        public IQueryable<T> Table => throw new NotImplementedException();

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
