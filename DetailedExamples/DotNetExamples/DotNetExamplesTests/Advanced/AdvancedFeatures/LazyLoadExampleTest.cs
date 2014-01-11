using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Advanced.AdvancedFeatures.Tests
{
	public class LazyLoadExampleTest
	{
		[Test()]
		public void TestLazy ()
		{
			Lazy<List<int>> samples = new Lazy<List<int>>( () => new List<int>(){1,2,3,4,5,6,7,8,9});

			Assert.IsFalse(samples.IsValueCreated);
			Assert.AreEqual(9, samples.Value.Count);
			Assert.IsTrue(samples.IsValueCreated);
		}
	}
}