using System;
using NUnit.Framework;
using Advanced.AdvancedFeatures;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture ()]
	public class NullableExampleTest
	{
		[Test ()]
		public void TestCase ()
		{
			int? aInput = null;
			int aNull = 999;
			
			int aValue = NullableExample.Coalesce (aInput, aNull);

			Assert.AreEqual (aValue, aNull);
		}
	}
}