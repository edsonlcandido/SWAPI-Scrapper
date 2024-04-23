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


    }
}
