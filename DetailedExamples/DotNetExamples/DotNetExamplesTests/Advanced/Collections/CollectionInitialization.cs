using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	public class CollectionInitializationTests
	{
		private struct Foo
		{
			public bool Moo { get; set; }
		}

		[Test ()]
		public void CollectionInitialization ()
		{
			int[] arrayInts = { 1, 2, 3 }; 
			Assert.AreEqual (3, arrayInts.Length);

			List<int> listInts = new List<int> { 1, 2, 3 };
			Assert.AreEqual (3, listInts.Count);

			ArrayList arrayListInts = new ArrayList { 1, 2, 3 };
			Assert.AreEqual (3, arrayListInts.Count);

			List<Foo> foos = new List<Foo> {
				new Foo{ Moo = true }, 
				new Foo{ Moo = false }
			};
			Assert.AreEqual (2, foos.Count); 
		}
	}
}