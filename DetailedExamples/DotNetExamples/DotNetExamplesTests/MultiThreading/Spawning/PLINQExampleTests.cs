using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MultiThreading.Spawning.Tests
{
	[TestFixture ()]
	public class PLINQExampleTests
	{
		[Test ()]
		public void TestWithExtensions ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.WithExtensions ());
		}

		[Test ()]
		public void TestWithNatural ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.WithNatural ());
		}

		[Test ()]
		public void TestWithDegreeOfParallelism ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.WithDegreeOfParallelism ());
		}

		[Test ()]
		public void TestAsOrdered ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 9, 8, 7, 1, 2, 3, 4, 5, 6 }, sut.AsOrdered ());
		}

		[Test ()]
		public void TestAsSequential ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.AsSequential ());
		}

		[Test ()]
		public void TestForAll ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (9, sut.ForAll ().Count); 
		}

		[Test ()]
		[ExpectedException]
		public void TestCancellationExtension ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.CancellationExtension ()); 
		}

		[Test ()]
		[ExpectedException]
		public void TestCancellatioNatural ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.CancellatioNatural ()); 
		}

		[Test ()]
		public void TestWithExecutionMode ()
		{
			var sut = new PLINQExample ();

			Assert.AreEqual (new List<int> (){ 1, 2, 3, 4, 5, 6, 7, 8, 9 }, sut.WithExecutionMode ()); 
		}
	}
}