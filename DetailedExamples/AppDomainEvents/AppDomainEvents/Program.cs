using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppDomainEvents
{
    class Program
    {
        private const string AssenblyToLoad = "FooLib";

        static void Main(string[] args)
        {
            SetUpCurrentAppDomain();
            var newAppDomain = SetUpNewAppDomain();
            LoadAssemblyAndProveItIsLoaded(newAppDomain, AssenblyToLoad);

            AppDomain.Unload(newAppDomain);
            Console.ReadLine();
        }

        private static void LoadAssemblyAndProveItIsLoaded(AppDomain appDomain, string assemblyName)
        {
            LoadAssembly(appDomain, assemblyName);
            FindAndPrintAssembly(appDomain, assemblyName);
        }

        private static void SetUpCurrentAppDomain()
        {
            SubscribeToAppDomainEvents(AppDomain.CurrentDomain);
        }

        private static AppDomain SetUpNewAppDomain()
        {
            var newAppDomain = AppDomain.CreateDomain("NewAppDomain");

            SubscribeToAppDomainEvents(newAppDomain);

            return newAppDomain;
        }

        private static void LoadAssembly(AppDomain newAppDomain, string assemblyName)
        {
            try
            {
                newAppDomain.Load(assemblyName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SubscribeToAppDomainEvents(AppDomain newAppDomain)
        {
            newAppDomain.DomainUnload += NewAppDomainDomainUnload;
            newAppDomain.AssemblyLoad += NewAppDomainAssemblyLoad;
            newAppDomain.ProcessExit += NewAppDomainProcessExit;
        }

        private static void NewAppDomainProcessExit(object sender, EventArgs e)
        {
            var appDomain = (AppDomain)sender;
            Console.WriteLine("Event.ProcessExit --> {0}", appDomain.FriendlyName);
        }

        private static void NewAppDomainDomainUnload(object sender, EventArgs e)
        {
            var appDomain = (AppDomain)sender;
            Console.WriteLine("Event.Unload --> {0}", appDomain.FriendlyName);
        }

        private static void NewAppDomainAssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            var appDomain = (AppDomain)sender;
            Console.WriteLine("Event.AssemblyLoad --> {0} in {1}", args.LoadedAssembly.GetName().Name, appDomain.FriendlyName);
        }

        private static void FindAndPrintAssembly(AppDomain appDomain, string assemblyName)
        {
            var anAssembly = appDomain.GetAssemblies().Where(assembly => assembly.GetName().Name.Equals(assemblyName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (anAssembly == null)
            {
                Console.WriteLine("Did not find Assembly {0} in {1})", assemblyName, appDomain.FriendlyName);
            }
            else
            {
                Console.WriteLine("Found Assembly --> {0} (version:{1}) in {2}", anAssembly.GetName().Name, anAssembly.GetName().Version, appDomain.FriendlyName);
            }
        }
    }
}
