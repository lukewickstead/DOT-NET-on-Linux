using System;

namespace ADODotNetAndMySQL.DAL.ADOProviders
{
    public interface IProviderFactory
    {
        IADODataProviderFactory GetADODataProviderFactory();        
    }
}

