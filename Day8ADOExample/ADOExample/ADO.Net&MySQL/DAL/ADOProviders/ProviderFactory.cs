using System;
using Ninject;
using ADODotNetAndMySQL.Utils;

namespace  ADODotNetAndMySQL.DAL.ADOProviders
{
    public class ProviderFactory : IProviderFactory
    {
        public IADODataProviderFactory GetADODataProviderFactory()
        {
            return InjectionFactory.Instance.kernel.Get<IADODataProviderFactory>();        
        }
    }
}

