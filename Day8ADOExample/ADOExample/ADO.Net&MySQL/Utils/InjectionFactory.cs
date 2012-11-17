using ADODotNetAndMySQL.DAL.ADOProviders;
using Ninject;
using System;

namespace ADODotNetAndMySQL.Utils
{
    public sealed class InjectionFactory
    {    
        public enum DbProbvider
        {
            MySql,
            Sqllite
        }

        private static volatile InjectionFactory injectionFactoryInstance;
        private static object syncRoot = new Object ();
        IKernel kernelInstance;

        public IKernel kernel
        {
            get { return kernelInstance; }
        }

        public void SetDbProvider(DbProbvider dbProvider)
        {
            kernelInstance = new StandardKernel();

            if( dbProvider == DbProbvider.MySql )
               kernel.Bind<IADODataProviderFactory>().To(typeof(MySQLADOProviderFactory));       
            else 
               kernel.Bind<IADODataProviderFactory>().To(typeof(SqlliteADOProviderFactory));       
        }

       public static InjectionFactory Instance {

        get {
            if (injectionFactoryInstance == null) {
                lock (syncRoot) {
                    if (injectionFactoryInstance == null) 
                        injectionFactoryInstance = new InjectionFactory ();
                }
            }

            return injectionFactoryInstance;
        }
    }
    }
}