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
        
        // IEnumerable : Trả dữ liệu Lưu dữ liệu lưu local xử lý dưới máy client
        // IQueryable: Xử lý dữ liệu trên máy chủ

        //Lưu thay đổi
        public async Task CommitAsync()
        {
            await _netCoreDbcontext.SaveChangesAsync();
        }

        // Xoá danh sách các đối tượng theo điều kiện
        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entitys = _netCoreDbcontext.Set<T>().Where(expression).ToList();
            if (entitys.Count > 0)
            {
                _netCoreDbcontext.Set<T>().RemoveRange(entitys);
            }
        }

        // Xoá một đối tượng theo điều kiện
        public void Delete(T entity)
        {
            EntityEntry entityEntry = _netCoreDbcontext.Entry(entity);
            entityEntry.State = EntityState.Deleted;
        }

        // Đọc danh sách các đối tượng theo điều kiện
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

        // Đọc dữ liệu đối tượng đầu tiên thoả mãn điều kiện
        public async Task<T> GetByIdAsync(object id)
        {
            return await _netCoreDbcontext.Set<T>().FindAsync(id);
        }

        // Lấy danh sách các đối tượng thoả mãn điều kiện
        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _netCoreDbcontext.Set<T>().FirstOrDefaultAsync();
        }

        // Thêm mới một đối tượng
        public async Task InsertAsync(T entity)
        {
            await _netCoreDbcontext.AddAsync(entity);
        }

        // Thêm mới nhiều đổi tượng khác nhau
        public async Task InsertAsync(IEnumerable<T> entities)
        {
            await _netCoreDbcontext.AddRangeAsync(entities);
        }

        // Cập nhật thông tin một đối tượng
        public void Update(T entity)
        {
            EntityEntry entityEntry = _netCoreDbcontext.Entry(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
