using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	[TestFixture ()]
	public class ListExampleTests
	{
		[Test ()]
		public void TestAddGetRemove ()
		{
			var foos = new List<string> (){ "1", "2", "3" };
			Assert.AreEqual (3, foos.Count);

			foos [2] = "MooFoey!";
			Assert.IsTrue (foos.Contains ("MooFoey!"));
			Assert.AreEqual ("MooFoey!", foos [2]);

			foos.Add ("Hello!");
			Assert.AreEqual (4, foos.Count);

			foos.Remove ("Hello!");
			Assert.AreEqual (3, foos.Count);

			foos.Insert (1, "foomoey!");
			Assert.AreEqual (4, foos.Count);

			foos.InsertRange (1, new List<string>{ "1", "2", "3" }); 
			Assert.AreEqual (7, foos.Count);

			foos.Clear ();
			Assert.IsEmpty (foos);
		}

		[Test ()]
		public void TestIteration ()
		{	
			var foos = new List<int> (){ 1, 2, 3 };
			var sum = 0;

			foreach (var foo in foos) {
				sum += foo;
			}

			Assert.AreEqual (6, sum);
		}

		[Test ()]
		public void TestCapacityAndTrim ()
		{
			var foos = new List<int> (){ 1, 2, 3 };

			Assert.Greater (foos.Capacity, foos.Count); 

			foos.TrimExcess ();
			Assert.AreEqual (foos.Count, foos.Capacity); 
		}

		[Test ()]
		public void TestAny ()
		{
			var foos = new List<string> (){ "fooey" };

			Assert.IsTrue (foos.Any (s => s.Equals ("FOOEY", 
				StringComparison.InvariantCultureIgnoreCase)));
		}

		[Test ()]
		public void TestContains ()
		{
			var foos = new List<string> (){ "fooey" };

			Assert.IsTrue (foos.Contains ("FOOEY", StringComparer.InvariantCultureIgnoreCase));
		}

		[Test ()]
		public void Foo ()
		{
			var foos = new List<string> (){ "aa", "Aa", "aa" };

			foos.Sort ();

			Assert.AreEqual ("aa", foos [0]);
			Assert.AreEqual ("aa", foos [1]);
			Assert.AreEqual ("Aa", foos [2]);

			foos = new List<string> (){ "aa", "Aa", "aa" };
			foos.Sort (StringComparer.InvariantCultureIgnoreCase);

			Assert.AreEqual ("aa", foos [0]);
			Assert.AreEqual ("Aa", foos [1]);
			Assert.AreEqual ("aa", foos [2]);
		}

		[Test ()]
		public void TestToArray ()
		{
			var foos = new List<string> (){ "aa", "Aa", "aa" };
			string[] fooArray = foos.ToArray ();

			Assert.IsInstanceOfType (typeof(string[]), fooArray);
		}
	}
}