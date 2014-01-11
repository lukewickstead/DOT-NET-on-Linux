using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	[TestFixture()]
	public class SortedSetExampleTests
	{
		public struct Foo
		{
			public int Age { get; set; }
		}

		public class FooComparer : IComparer<Foo>
		{
			public int Compare (Foo a, Foo b)
			{
				return a.Age.CompareTo (b.Age);      
			}
		}

		[Test()]
		public void TestExample ()
		{
			var foos = new SortedSet<Foo> (new FooComparer ());
			foos.Add (new Foo (){ Age = 9 });
			foos.Add (new Foo (){ Age = 5 });
			foos.Add (new Foo (){ Age = 11 });
			foos.Add (new Foo (){ Age = 1 });

			Assert.AreEqual (1, foos.Min.Age);
			Assert.AreEqual (11, foos.Max.Age);
		}
	}
}