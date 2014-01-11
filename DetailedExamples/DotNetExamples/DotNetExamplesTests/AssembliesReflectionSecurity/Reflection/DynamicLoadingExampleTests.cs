using NUnit.Framework;
using System;
using System.Reflection;

namespace  AssembliesReflectionSecurity.Reflection.Tests
{
	[TestFixture ()]
	public class DynamicLoadingExampleTests
	{
		[Test ()]
		public void TesytAssemblyReflection ()
		{
			var aAssembly = DynamicLoadingExample.GetMSCorLibAssembly ();

			Assert.IsFalse (aAssembly.GlobalAssemblyCache);
			Assert.AreEqual ("mscorlib", aAssembly.GetName ().Name);
			Assert.Greater (aAssembly.GetName ().Version.Major, 1);
			Assert.IsTrue (aAssembly.FullName.Contains ("mscorlib"));
			Assert.IsNotEmpty (aAssembly.GetTypes ());
			Assert.IsNotNull (aAssembly.GetType ("System.Int32", false, true));
		}

		[Test ()]
		public void TestDynamicLoading ()
		{
			var anAssembly = Assembly.Load ("mscorlib");

			var aType = anAssembly.GetType ("System.Collections.ArrayList");

			Object aFoo = Activator.CreateInstance (aType);

			aType.GetMethod ("Add", new [] { typeof(object) }).Invoke (aFoo, new object[] { 1 });

			var aValue = (bool)aType.GetMethod ("Contains", new [] { typeof(int) }).Invoke (aFoo, new object[] { 1 });

			Assert.AreEqual (true, aValue);

			aType.GetMethod ("Clear").Invoke (aFoo, new object[]{ });

			var count = (int)aType.GetProperty ("Count").GetValue (aFoo, null);

			Assert.AreEqual (count, 0);		
		}
	}
}