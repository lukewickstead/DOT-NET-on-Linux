using NUnit.Framework;
using System;

namespace ADO.ConnectedLayer.Tests
{
	[TestFixture ()]
	public class TransactionsExampleTests
	{
		[Test ()]
		public void TestWithTry ()
		{
			var sut = new TransactionsExample ();
			sut.WithTry ();

			Assert.IsTrue (sut.IsHit);
		}

		[Test ()]
		[ExpectedException]
		public void TestWithUsing ()
		{
			var sut = new TransactionsExample ();
			sut.WithUsing ();

			Assert.IsFalse (sut.IsHit);
		}
	}
}

