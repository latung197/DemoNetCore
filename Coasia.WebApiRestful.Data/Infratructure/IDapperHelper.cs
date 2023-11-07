using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Data.Infratructure
{
    public interface IDapperHelper<T> where T : class
    {
        /// <summary>
        /// Execute raw query not return any values
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parammeters"></param>
        void NpgExecuteNotReturn(string query, DynamicParameters parammeters = null);
        Task<T> NpgExecuteReturnScalar<T>(string query, DynamicParameters parammeters = null);
        Task<IEnumerable<T>> NpgExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null);
        Task<IEnumerable<T>> NpgExecuteFuntionReturnList<T>(string query, DynamicParameters parammeters = null);
        public T NpgGetById(int Id);
        public  IEnumerable<T> NpgGetAll();
        public T NpgAdd(T entity);
        public T NpgDelete(int Id);
        public bool NpgUpdate(T entity);


        void ExecuteNotReturn(string query, DynamicParameters parammeters = null);
        Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters parammeters = null);
        Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null);
        Task<IEnumerable<T>> ExecuteFuntionReturnList<T>(string query, DynamicParameters parammeters = null);
        public T GetById(int Id);
        public IEnumerable<T> GetAll();
        public T Add(T entity);
        public T Delete(int Id);
        public bool Update(T entity);
    }
}
