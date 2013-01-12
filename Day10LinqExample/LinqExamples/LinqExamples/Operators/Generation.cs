using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Generation
	{

		[Test()]
		public void Range_LinqExt ()
		{
			// Range of x
			var sampleInts = Enumerable.Range(1, 10);

			Assert.AreEqual (10, sampleInts.Count());
			Assert.AreEqual (1, sampleInts.First());
			Assert.AreEqual (10, sampleInts.Last());
		}

		[Test()]
		public void Repeat_LinqExt ()
		{
			// First person ordered by name
			var sampleInts = Enumerable.Repeat(1, 10);

			Assert.AreEqual (10, sampleInts.Count());
			Assert.AreEqual (1, sampleInts.First());
			Assert.AreEqual (1, sampleInts.Last());
			Assert.AreEqual (10, sampleInts.Sum());		
		}
	}
}