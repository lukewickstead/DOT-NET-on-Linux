using System;
using System.Reflection;
using System.Collections.Generic;

namespace AssembliesReflectionSecurity.DynamicRuntime
{
	public class DynamicTypeExample
	{
		public static int WithDynamic ()
		{
			var anAssembly = Assembly.Load ("mscorlib");

			Type arrayListType = anAssembly.GetType ("System.Collections.ArrayList");     

			dynamic anArrayList = Activator.CreateInstance (arrayListType);     

			dynamic t = "Hello!";  
			anArrayList.Add (t);

			t = false;
			anArrayList.Add (t);

			t = new List<int> ();
			anArrayList.Add (t);

			t = anArrayList [0];
			anArrayList.Add (t);

			return anArrayList.Count;
		}

		public static int WithoutDynamic ()
		{		
			var anAssembly = Assembly.Load ("mscorlib");

			Type arrayListType = anAssembly.GetType ("System.Collections.ArrayList");     

			Object anArrayList = Activator.CreateInstance (arrayListType);     

			anArrayList.GetType ().GetMethod ("Add").Invoke (anArrayList, new object[] { 1 });
			return (int)anArrayList.GetType ().GetProperty ("Count").GetValue (anArrayList);
		}
	}
}