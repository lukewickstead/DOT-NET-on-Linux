using NUnit.Framework;
using Advanced.AdvancedFeatures;
using System;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture ()]
	public class CheckedUncheckedExampleTest
	{
		[Test ()]
		[ExpectedException (typeof(OverflowException))]
		public void TestIncrementWithCheckedRegion ()
		{
			CheckedUncheckedAdder.IncrementWithCheckedRegion (int.MaxValue);
		}

		[Test ()]
		[ExpectedException (typeof(OverflowException))]
		public void TestIncrementWithCheckedFunction ()
		{
			CheckedUncheckedAdder.IncrementWithCheckedFunction (int.MaxValue);
		}

		[Test ()]
		public void TestIncrementWithUncheckedRegion ()
		{
			var output = CheckedUncheckedAdder.IncrementWithUncheckedRegion (int.MaxValue);

			Assert.AreEqual (int.MinValue, output);
		}

		[Test ()]
		public void TestIncrementWithUncheckedFunction ()
		{
			var output = CheckedUncheckedAdder.IncrementWithUncheckedFunction (int.MaxValue);

			Assert.AreEqual (int.MinValue, output);
		}
	}
}