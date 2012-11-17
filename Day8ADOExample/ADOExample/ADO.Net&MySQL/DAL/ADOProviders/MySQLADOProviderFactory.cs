using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ADODotNetAndMySQL.DAL.ADOProviders
{
    public class MySQLADOProviderFactory : IADODataProviderFactory
    {
        public IDbConnection GetConnection()
        {           
            return new MySqlConnection(GetDBConnectionString());
        }

        public IDbDataAdapter GetDataAdapter()
        {                
            return new MySqlDataAdapter();
        }

        public string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings ["DotNetOnLinux"].ConnectionString;
        }
    }
}

