using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	public class QueueExampleTests
	{
		[Test ()]
		public void TestExample ()
		{
			var foos = new Queue<int> ();

			foos.Enqueue (1);
			Assert.AreEqual (1, foos.Peek ());

			foos.Enqueue (2);
			Assert.AreEqual (1, foos.Peek ());

			Assert.AreEqual (1, foos.Dequeue ());
			Assert.AreEqual (2, foos.Peek ());
		}
	}
}