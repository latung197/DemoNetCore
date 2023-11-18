using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using System.Data;
using static Dapper.SqlMapper;
using Coasia.WebApiRestful.Data.Abstract;
using Microsoft.Data.SqlClient;

namespace Coasia.WebApiRestful.Data.Infratructure
{
    public class DapperHelper<T> : IDapperHelper<T> where T : class
    {
        private readonly string connectString = string.Empty;

        //public DapperHelper(IConfiguration configuration)
        //{

        //}

        #region Data Postgrest
        public T NpgAdd(T Entity)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectString);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    connection.Insert(Entity);
                    return Entity;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        public void NpgExecuteNotReturn(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new NpgsqlConnection(connectString))
            {
                dbConnection.ExecuteAsync(query, parammeters, commandType: CommandType.Text);
            }
        }

        public async Task<T> NpgExecuteReturnScalar<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new NpgsqlConnection(connectString))
            {
                return (T)Convert.ChangeType(await dbConnection.ExecuteScalarAsync<T>(query, parammeters, commandType: CommandType.Text), typeof(T));
            }
        }

        public async Task<IEnumerable<T>> NpgExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new NpgsqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<T>> NpgExecuteFuntionReturnList<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new NpgsqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.Text);
            }
        }
        public IEnumerable<T> NpgGetAll()
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectString);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    return connection.GetAll<T>();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<T> NpgUpdate(T entity)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectString);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    return (T)Convert.ChangeType(await connection.UpdateAsync(entity), typeof(T));
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public T NpgGetById(int Id)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectString);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    return connection.Get<T>(Id);
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<T> NpgDelete(T entity)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectString);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    return (T)Convert.ChangeType(await connection.DeleteAsync(entity), typeof(T));
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        #endregion
        #region Database SQLServer
        // Thực thi câu truy vấn và không trả về kết quả
        public void ExecuteNotReturn(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                dbConnection.ExecuteAsync(query, parammeters, commandType: CommandType.Text);
            }
        }
        // Thực thi câu lệnh trả về một kết quả
        public async Task<T> ExecuteReturnScalar<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return (T)Convert.ChangeType(await dbConnection.ExecuteScalarAsync<T>(query, parammeters, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }
        // Thực thi câu lệnh trả về danh sách các hàm thoả mãn
        public async Task<IEnumerable<T>> ExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.Text);
            }
        }

        // Thực thi gọi chạy StoreProceduct trả về danh sách kết quả
        public async Task<IEnumerable<T>> ExecuteStoreProcedureReturnList<T>(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                return await dbConnection.QueryAsync<T>(query, parammeters, commandType: CommandType.StoredProcedure);
            }
        }

        // Thực thi câu lệnh trả về một dòng thoả mãn điều kiện
        public T GetById(int Id)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                dbConnection.Open();
                return dbConnection.Get<T>(Id);
            }
        }

        // Thực thi câu lệnh lấy tất cả giá trị của bảng
        public IEnumerable<T> GetAll()
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                dbConnection.Open();
                return dbConnection.GetAll<T>();
            }
        }

        // Thêm mới một dối tượng
        public T Add(T entity)
        {
            try
            {

                using (var dbConnection = new SqlConnection(connectString))
                {
                    dbConnection.Open();
                    dbConnection.Insert(entity);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Xoá một đối tượng với biến gồm bảng, cột khoá chính, Khoá chính
        public bool Delete(string table, string columnkey, string Id)
        {
            try
            {
                using (var dbConnection = new SqlConnection(connectString))
                {
                    string str = "delete from " + table + " where " + columnkey + "= " + Id + ";";
                    //string str1 = @"delete from {0} where {1} = {2};";
                    //string.Format(str1,table,columnkey,Id);
                    dbConnection.Open();
                    dbConnection.ExecuteScalar(str);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string table, string where)
        {
            try
            {
                using (var dbConnection = new SqlConnection(connectString))
                {
                    string str = "delete from " + table + " where " + where + ";";
                    //string str1 = @"delete from {0} where {1};";
                    //string.Format(str1,table,where);
                    dbConnection.Open();
                    dbConnection.Execute(str);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public T Delete(T entity)
        {
            try
            {

                using (var dbConnection = new SqlConnection(connectString))
                {
                    dbConnection.Open();
                    dbConnection.Delete(entity);
                    return entity;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(T entity)
        {
            try
            {

                using (var dbConnection = new SqlConnection(connectString))
                {
                    dbConnection.Open();
                    dbConnection.Update(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

    }
}
