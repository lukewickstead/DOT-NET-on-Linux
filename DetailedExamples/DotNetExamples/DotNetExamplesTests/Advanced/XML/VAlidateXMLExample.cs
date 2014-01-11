using NUnit.Framework;
using System;
using Advanced.XML;

namespace Advanced.XML.Tests
{
	[TestFixture ()]
	public class VAlidateXMLExample
	{
		[Test ()]
		public void TestCase ()
		{
			var sut = new VAlidateXML ();
	
			// Allows incorrect xml validation
			Assert.IsFalse (sut.HasError);
			Assert.IsFalse (sut.HasWarning);
		}
	}
}