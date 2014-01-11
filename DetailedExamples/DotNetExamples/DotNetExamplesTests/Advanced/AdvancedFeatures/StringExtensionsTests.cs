using NUnit.Framework;
using System;
using Advanced.AdvancedFeatures;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture ()]
	public class StringExtensionsTests
	{
		[Test ()]
		public void TestIsPalindrome ()
		{				
			Assert.IsTrue("ABBA".IsPalindrome());			
		}
	}
}