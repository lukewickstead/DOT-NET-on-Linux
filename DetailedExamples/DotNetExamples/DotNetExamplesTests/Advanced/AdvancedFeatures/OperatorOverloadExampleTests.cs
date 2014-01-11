using System;
using NUnit.Framework;
using Advanced.AdvancedFeatures;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture ()]
	public class OperatorOverloadExampleTests
	{
		[Test ()]
		public void TestAdd ()
		{
			var one = new ClassA (10);
			var two = new ClassA (10);

			var three = one + two;

			Assert.AreEqual (one.Value + two.Value, three.Value);
		}

		[Test ()]
		public void TestAddInt ()
		{
			var one = new ClassA (10);

			var two = one + 1;

			Assert.AreEqual (one.Value + 1, two.Value);
		}

		[Test ()]
		public void TestPostIncrement ()
		{
			var one = new ClassA (10);

			var two = one++;

			Assert.AreEqual (11, one.Value);
			Assert.AreEqual (11, two.Value);
		}

		[Test ()]
		public void TestPostDecrement ()
		{
			var one = new ClassA (10);

			var two = one--;

			Assert.AreEqual (9, one.Value);
			Assert.AreEqual (9, two.Value);
		}

		[Test ()]
		public void TestPreIncrement ()
		{
			var one = new ClassA (10);

			var two = ++one;

			Assert.AreEqual (11, one.Value);
			Assert.AreEqual (11, two.Value);
		}

		[Test ()]
		public void TestPreDecrement ()
		{
			var one = new ClassA (10);

			var two = --one;

			Assert.AreEqual (9, one.Value);
			Assert.AreEqual (9, two.Value);
		}

		[Test ()]
		public void TestExplicitCast ()
		{
			ClassB classB = (ClassB)new ClassA (1);

			Assert.AreEqual (1, classB.Value);
		}

		[Test ()]
		public void TestImplicitCast ()
		{
			ClassC classC = new ClassA (1);

			Assert.AreEqual (1, classC.Value);
		}

		[Test ()]
		public void TestComparative ()
		{
			var one = new ClassA (10);
			var two = new ClassA (10);
			var three = new ClassA (11);

			Assert.IsTrue (one == two);
			Assert.IsTrue (one != three);

			Assert.IsTrue (one <= two);
			Assert.IsTrue (one < three);

			Assert.IsTrue (one >= two);
			Assert.IsTrue (three > one);
		}

		[Test ()]
		public void TestCompare ()
		{
			var one = new ClassA (10);
			var two = new ClassA (11);
			var three = new ClassA (10);

			Assert.AreEqual (0, one.CompareTo (three));
			Assert.AreEqual (-1, one.CompareTo (two));
			Assert.AreEqual (1, two.CompareTo (one));
		}
	}
}