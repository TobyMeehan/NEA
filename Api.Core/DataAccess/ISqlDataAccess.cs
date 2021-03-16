using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters);

        Task<int> ExecuteAsync(string sql, object parameters);
    }
}
