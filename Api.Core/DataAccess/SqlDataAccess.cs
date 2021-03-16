using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly Func<IDbConnection> _connectionFactory;

        public SqlDataAccess(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<int> ExecuteAsync(string sql, object parameters)
        {
            using (IDbConnection connection = _connectionFactory.Invoke())
            {
                return connection.ExecuteAsync(sql, parameters);
            }
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters)
        {
            using (IDbConnection connection = _connectionFactory.Invoke())
            {
                return connection.QueryAsync<T>(sql, parameters);
            }
        }
    }
}
