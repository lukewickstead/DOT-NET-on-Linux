using NUnit.Framework;
using AssembliesReflectionSecurity.DynamicRuntime;

namespace AssembliesReflectionSecurity.DynamicRuntime.Tests
{
	[TestFixture ()]
	public class DynamicTypeExampleTests
	{
		[Test ()]
		public void TestWithDynamic ()
		{
			Assert.AreEqual (4, DynamicTypeExample.WithDynamic ());
		}

		[Test ()]
		public void TestWithoutDynamic ()
		{
			Assert.AreEqual (1, DynamicTypeExample.WithoutDynamic ());
		}
	}
}