using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	[TestFixture ()]
	public class HashSetExampleTests
	{
		[Test ()]
		public void TestAddCountAndContains ()
		{
			var aSet = new HashSet<int> ();  

			Assert.IsTrue (aSet.Add (1));
			Assert.IsFalse (aSet.Add (1));
			Assert.AreEqual (1, aSet.Count); 
			Assert.IsTrue (aSet.Contains (1));
		}

		[Test ()]
		public void TestUnionWith ()
		{
			var aSet = new HashSet<int> { 1 };  
			var bSet = new HashSet<int> { 1, 2 };  

			aSet.UnionWith (bSet);

			Assert.IsTrue (aSet.Contains (1));
			Assert.IsTrue (aSet.Contains (2));
			Assert.AreEqual (2, aSet.Count);
		}

		[Test ()]
		public void TestExceptWith ()
		{
			var aSet = new HashSet<int> { 1, 2 };  
			var bSet = new HashSet<int> { 1 };  

			aSet.ExceptWith (bSet);

			Assert.IsTrue (aSet.Contains (2));
			Assert.IsFalse (aSet.Contains (1));
			Assert.AreEqual (1, aSet.Count);
		}

		[Test ()]
		public void TestIntersectWith ()
		{
			var aSet = new HashSet<int> { 1, 2 };  
			var bSet = new HashSet<int> { 1 };  

			aSet.IntersectWith (bSet);

			Assert.IsTrue (aSet.Contains (1));
			Assert.IsFalse (aSet.Contains (2));
			Assert.AreEqual (1, aSet.Count);
		}

		[Test ()]
		public void TestSubSetSuperSet ()
		{
			var aSet = new HashSet<int> { 1, 2 };  
			var bSet = new HashSet<int> { 1 };  
		
			Assert.IsTrue (aSet.IsSubsetOf (aSet));
			Assert.IsTrue (bSet.IsSubsetOf (aSet));

			Assert.IsTrue (bSet.IsProperSubsetOf (aSet));
			Assert.IsFalse (aSet.IsProperSubsetOf (aSet));

			Assert.IsTrue (aSet.IsSupersetOf (aSet));
			Assert.IsTrue (aSet.IsSupersetOf (bSet));

			Assert.IsTrue (aSet.IsProperSupersetOf (bSet));
			Assert.IsFalse (aSet.IsProperSupersetOf (aSet));
		}

		[Test ()]
		public void TestOverlaps ()
		{
			var aSet = new HashSet<int> { 1, 2 };  
			var bSet = new HashSet<int> { 1 };  

			Assert.IsTrue (aSet.Overlaps (bSet));
		}
	}
}