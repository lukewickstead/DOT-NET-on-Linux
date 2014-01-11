using NUnit.Framework;
using System;
using System.Xml;
using Advanced.XML;

namespace Advanced.XML.Tests
{
	[TestFixture ()]
	public class BuildLoadSaveParseExampleTests
	{
		[Test ()]
		public void TestSaveLoad ()
		{
			var aDoc = BuildLoadSaveParseExample.GetXDocument ();
			var aFileName = BuildLoadSaveParseExample.Save (aDoc);
			var outDoc = BuildLoadSaveParseExample.Load (aFileName);	

			Assert.AreEqual (aDoc.ToString (), outDoc.ToString ());	
		}

		[Test ()]
		public void TestParse ()
		{
			var aDoc = BuildLoadSaveParseExample.GetXDocument ();
			var outDoc = BuildLoadSaveParseExample.Parse (aDoc.ToString ());	

			Assert.AreEqual (aDoc.ToString (), outDoc.ToString ());	
		}
	}
}