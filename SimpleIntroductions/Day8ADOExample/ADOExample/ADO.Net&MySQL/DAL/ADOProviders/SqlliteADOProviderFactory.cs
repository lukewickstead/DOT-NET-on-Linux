using Mono.Data.Sqlite;
using System;
using System.Data;

namespace ADODotNetAndMySQL.DAL.ADOProviders
{
    public class SqlliteADOProviderFactory : IADODataProviderFactory
    {
        public IDbConnection GetConnection()
        {           
            return new SqliteConnection(GetDBConnectionString());
        }

        public IDbDataAdapter GetDataAdapter()
        {                
            return new SqliteDataAdapter();
        }

        public string GetDBConnectionString()
        {
            // Data Source=c:\mydb.db;Version=3;
            return System.Configuration.ConfigurationManager.ConnectionStrings ["DotNetOnLinuxSQLLite"].ConnectionString;
        }
    }
}

