using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Collections.Tests
{
	[TestFixture()]
	public class StackExampleTests
	{
		[Test ()]
		public void TestStackExample ()
		{
			var fooStack = new Stack<int> ();

			fooStack.Push (1);
			Assert.AreEqual (1, fooStack.Peek ());

			fooStack.Push (2);
			Assert.AreEqual (2, fooStack.Peek ());

			Assert.AreEqual (2, fooStack.Pop ());
			Assert.AreEqual (1, fooStack.Peek ());
		}
	}
}