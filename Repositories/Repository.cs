using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Repositories
{
    public class Repository<T> where T : class 
    {
        private readonly SqliteConnection _connection;
        public Repository(SqliteConnection connection)
        {
            _connection = connection;
        }

        //use dapper contrib to insert
        public async Task Insert(T entity)
        {
            await _connection.InsertAsync(entity);
        }

        //use dapper contrib to get one
        public async Task<T> Get(int id)
        {
            return await _connection.GetAsync<T>(id);
        }
    }
}
