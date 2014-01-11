using System;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	[TestFixture ()]
	public class ArrayExampleTests
	{
		[Test ()]
		public void TestIndexMethod ()
		{
			int[] myInts = new int[1];

			myInts [0] = 999;

			Assert.AreEqual (999, myInts [0]);
			Assert.AreEqual (1, myInts.Length);
		}

		[Test ()]
		public void TestCollectionInitializer ()
		{
			var collInitOne = new int[] { 1, 2, 3 };
			Assert.AreEqual (3, collInitOne.Length);

			int[] collInitTwo = { 1, 2, 3, 4 }; 
			Assert.AreEqual (4, collInitTwo.Length);

			var collInitThree = new int[5] { 1, 2, 3, 4, 5 };
			Assert.AreEqual (5, collInitThree.Length);
		}

		[Test ()]
		public void TestMultiDimensionArray ()
		{
			var mdArray = new int[3, 3];
			mdArray [1, 2] = 9;

			Assert.AreEqual (9, mdArray [1, 2]);
		}

		[Test ()]
		public void TestJaggedArray ()
		{
			var jaggedArray = new int[6][];
			jaggedArray [0] = new int[2];
			jaggedArray [1] = new int[20];

			Assert.AreEqual (6, jaggedArray.Length);
			Assert.AreEqual (2, jaggedArray [0].Length);
			Assert.AreEqual (20, jaggedArray [1].Length);

		}

		[Test ()]
		public void TestSort ()
		{
			var sortArray = new int[] { 1, 2, 3 };

			Array.Sort (sortArray);
			Assert.AreEqual (1, sortArray [0]);

			Array.Reverse (sortArray);
			Assert.AreEqual (3, sortArray [0]);
		}
	}
}