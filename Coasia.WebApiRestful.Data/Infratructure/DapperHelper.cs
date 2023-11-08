using Coasia.WebApiRestful.Domain.Entitys;
using Dapper;
using Dapper.Contrib.Extensions;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.SqlClient;

namespace Coasia.WebApiRestful.Data.Infratructure
{
    public class DapperHelper<T> : IDapperHelper<T> where T : class
    {
        private readonly string connectString = string.Empty;

        //public DapperHelper(IConfiguration configuration)
        //{

        //}
        public T NpgAdd(T Entity)
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectString);
            var dataSource = dataSourceBuilder.Build();
            using (var connection = dataSource.OpenConnection())
            {
                try
                {
                    connection.InsertAsync(Entity);
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
                return (T)Convert.ChangeType(await dbConnection.ExecuteScalarAsync<T>(query, parammeters, commandType:CommandType.Text), typeof(T));
            }
        }

        public async Task<IEnumerable<T>> NpgExecuteSqlReturnList<T>(string query, DynamicParameters parammeters = null)
        {
            using(var  dbConnection = new NpgsqlConnection(connectString))
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
                    return (T)Convert.ChangeType( await connection.UpdateAsync(entity),typeof(T)); 
                }
                catch (Exception ex)
                {

                    return null;

                }
            }
        }

        public T NpgGetById(int Id)
        {
            throw new NotImplementedException();
        }

        public T NpgDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNotReturn(string query, DynamicParameters parammeters = null)
        {
            using (var dbConnection = new SqlConnection(connectString))
            {
                dbConnection.ExecuteAsync(query, parammeters, commandType: CommandType.Text);
            }
        }

        public Task<T1> ExecuteReturnScalar<T1>(string query, DynamicParameters parammeters = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T1>> ExecuteSqlReturnList<T1>(string query, DynamicParameters parammeters = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T1>> ExecuteFuntionReturnList<T1>(string query, DynamicParameters parammeters = null)
        {
            throw new NotImplementedException();
        }

        public T GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

    }
}
