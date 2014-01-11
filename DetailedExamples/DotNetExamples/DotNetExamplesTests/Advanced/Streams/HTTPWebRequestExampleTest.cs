using NUnit.Framework;
using System;
using Advanced.Streams;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class HTTPWebRequestExampleTest
	{
		[Test ()]
		public void TestCase ()
		{
			var foo = HTTPWebRequestExample.Get ("http://www.google.co.uk");

			Assert.IsNotEmpty (foo);
			Assert.IsTrue (foo.Contains ("google"));
			Assert.IsTrue (foo.Contains ("doodle"));
		}
	}
}