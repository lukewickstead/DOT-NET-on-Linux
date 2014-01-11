using NUnit.Framework;
using System;
using System.Threading;

namespace MultiThreading.ProcessAppDomains.Tests
{
	[TestFixture ()]
	public class ContextBoundObjectExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var context = Thread.CurrentContext;
			var contextId = context.ContextID;
			var contextProperties = context.ContextProperties;

			Assert.IsNotNull (context);
			Assert.GreaterOrEqual (0, contextId);

			foreach (var prop in contextProperties) {
				Assert.IsNotEmpty (prop.Name);
			}
		}
	}
}