using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	public class DictionaryExampleTests
	{
		private struct Foo
		{
		}

		[Test ()]
		public void TestAddGet ()
		{
			var aDict = new Dictionary<string, Foo> ();

			aDict.Add ("MyFoo", new Foo ());

			Assert.AreEqual (1, aDict.Count);

			aDict ["MyFoo"] = new Foo (); 
			Assert.AreEqual (1, aDict.Count);

			Assert.AreEqual (new Foo (), aDict ["MyFoo"]);

			Foo foo;
			aDict.TryGetValue ("MyFoo", out foo);

			Assert.IsNotNull (foo);
			Assert.IsTrue (aDict.ContainsKey ("MyFoo"));

			aDict.Remove ("MyFoo");
			Assert.IsFalse (aDict.ContainsKey ("MyFoo"));
		}

		[Test ()]
		public void TestIteration ()
		{
			var aDict = new Dictionary<string, int> ();
			aDict.Add ("One", 1);
			aDict.Add ("Two", 2);
			aDict.Add ("Three", 3);

			var count = 0;
			var sum = 0;

			foreach (KeyValuePair<string, int> kvp  in aDict) {
				count += kvp.Key.Length;
				sum += kvp.Value;
			}

			Assert.AreEqual (11, count);
			Assert.AreEqual (6, sum);
		}

		[Test ()]
		public void TestKeyAndValueCollections ()
		{
			var aDict = new Dictionary<string, int> ();

			Dictionary<string, int>.ValueCollection valueColl = aDict.Values;
			Dictionary<string, int>.KeyCollection keyColl = aDict.Keys;

			Assert.IsEmpty (valueColl);
			Assert.IsEmpty (keyColl);

			aDict.Add ("Boo", 1);

			Assert.IsNotEmpty (valueColl);
			Assert.IsNotEmpty (keyColl);
		}

		public void TestCaseInsensativeDictionary ()
		{
			var aDict = new Dictionary<string, int> (
				            StringComparer.CurrentCultureIgnoreCase);

			aDict ["foo"] = 1;
			Assert.IsTrue (aDict.ContainsKey ("FOO"));
		}
	}
}