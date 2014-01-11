using NUnit.Framework;
using System;

namespace Advanced.XML.Tests
{
	[TestFixture ()]
	public class HydrationExampleTests
	{
		[Test ()]
		public void TestBuild ()
		{
			var aDoc = HydrationExample.BuildXElement ();
			var bDoc = HydrationExample.BuildXElementWithLinq ();

			Assert.AreEqual (aDoc.ToString (), bDoc.ToString ());
		}
	}
}