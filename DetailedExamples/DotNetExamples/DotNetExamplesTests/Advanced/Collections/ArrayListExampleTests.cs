using System;
using System.Collections;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	public class ArrayListExampleTests
	{
		[Test()]
		public void TestAddRemove()
		{
			ArrayList anArrayList = new ArrayList();

			anArrayList.Add("Foo");
			Assert.AreEqual (1, anArrayList.Count);
			Assert.AreEqual ("Foo", anArrayList[0]);

			anArrayList[0] = "Moo"; 
			Assert.AreEqual (1, anArrayList.Count);

			anArrayList.Remove("Moo");
			Assert.AreEqual (0, anArrayList.Count);

			anArrayList.Add("Foo");
			Assert.AreEqual (1, anArrayList.Count);

			anArrayList.RemoveAt(0);
			Assert.AreEqual (0, anArrayList.Count);
		}

		[Test()]
		public void TestInsert()
		{
			ArrayList anArrayList = new ArrayList();		

			anArrayList.Insert( anArrayList.Count, "Moo!" ); 

			Assert.AreEqual (1, anArrayList.Count);
			Assert.AreSame ("Moo!", anArrayList[0]);

			anArrayList.InsertRange( 1, new ArrayList(){1,2,3,4,5,6,7,8,9} );

			Assert.AreEqual (10, anArrayList.Count);
		}

		[Test()]
		public void TestIteration()
		{
			var count = 0;
			ArrayList anArrayList = new ArrayList (){ 1, 2, 3 };	
						
			foreach ( Object item in anArrayList )
			{
				count++;
			}

			Assert.AreEqual (3, count);
		}

		[Test()]
		public void TestToArray()
		{
			ArrayList anArrayList = new ArrayList (){ 1, 2, 3 };	

			Assert.IsInstanceOfType (typeof(object[]), anArrayList.ToArray());
		}

		[Test()]
		public void TestSort()
		{
			ArrayList anArrayList = new ArrayList (){ 1, 2, 3 };	
		
			anArrayList.Sort ();
			Assert.AreEqual (1, anArrayList [0]);

			anArrayList.Reverse ();
			Assert.AreEqual (3, anArrayList [0]);
		}
	}
}