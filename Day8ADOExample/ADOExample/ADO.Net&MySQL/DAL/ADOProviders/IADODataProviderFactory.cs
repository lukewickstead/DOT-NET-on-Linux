using System;
using System.Data;

namespace ADODotNetAndMySQL.DAL.ADOProviders
{
    public interface IADODataProviderFactory
    {  
        IDbConnection GetConnection();

        IDbDataAdapter GetDataAdapter();

        string GetDBConnectionString();
    }
}

