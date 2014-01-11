using System;
using System.Reflection;

namespace AssembliesReflectionSecurity.Reflection
{
	public class DynamicLoadingExample
	{
		public static Assembly GetLoadFrom ()
		{
			return Assembly.LoadFrom (@"C:\foo.dll");
		}

		public static Assembly GetLoad ()
		{
			return Assembly.Load (@"Foo, Version=1.0.0.0, PublicKeyToken=xxx, Culture=neutral");   
		}

		public static Assembly GetLoadWithAssemblyName ()
		{
			return Assembly.Load (
				new AssemblyName ("Foo") { 
					Version = new Version ("1.0.0.0") 
				});
		}

		public static Assembly GetMSCorLibAssembly ()
		{
			return Assembly.Load ("mscorlib");			 		
		}
	}
}