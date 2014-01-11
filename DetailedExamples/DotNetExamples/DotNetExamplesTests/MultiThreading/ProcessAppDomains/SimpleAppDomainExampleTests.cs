using System;
using System.Reflection;
using NUnit.Framework;

namespace MultiThreading.ProcessAppDomains.Tests
{
	[TestFixture ()]
	public class SimpleAppDomainExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;

			Assert.Greater(currentDomain.Id, 0);
			Assert.IsFalse(currentDomain.IsDefaultAppDomain());
			Assert.IsTrue(currentDomain.FriendlyName.Contains("DotNetExamplesTests"));
			Assert.IsTrue(currentDomain.BaseDirectory.Contains("DotNetExamplesTests"));
			Assert.Greater(currentDomain.GetAssemblies ().Length, 0 );
		}
	}
}