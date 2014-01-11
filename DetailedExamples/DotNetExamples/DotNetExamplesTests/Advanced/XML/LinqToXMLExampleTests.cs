using NUnit.Framework;
using System;
using Advanced.XML;

namespace Advanced.XML.Tests
{
	[TestFixture ()]
	public class LinqToXMLExampleTests
	{
		[Test ()]
		public void TestQueryInt ()
		{
			var sut = new LinqToXMLExample ();
			Assert.AreEqual(2, sut.GetAnIntes (2));
		}

		[Test ()]
		public void TestQueryString ()
		{
			var sut = new LinqToXMLExample ();
			Assert.AreEqual(4, sut.GetAStrings ().Count);
		}

		[Test ()]
		public void TestAdd ()
		{
			var sut = new LinqToXMLExample ();
			Assert.AreEqual(5, sut.Add ());
		}

		[Test ()]
		public void TestRemove ()
		{
			var sut = new LinqToXMLExample ();
			Assert.AreEqual(3, sut.Remove ());
		}

		[Test ()]
		public void TestEdit ()
		{
			var sut = new LinqToXMLExample ();
			Assert.AreEqual(5, sut.Edit ());
		}
	}
}