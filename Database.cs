using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;

namespace SWAPI_Scrapper
{
    public static class Database
    {
        public static SqliteConnection Connection { get; set; }
    }
}
