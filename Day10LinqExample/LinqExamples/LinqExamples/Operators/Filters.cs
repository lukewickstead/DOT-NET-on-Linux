using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Filters
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void Where_LinqExt ()
		{
			// Which parents are less thann 30
			Assert.AreEqual (3, people.Where (x => x.Age < 30).Count ());
		}

		[Test()]
		public void Where_Linq ()
		{
			// Which parents are less thann 30

			var count = (from p in people
			             where p.Age < 30
			             select p).Count ();

			Assert.AreEqual (3, count);
		}

		[Test()]
		public void WhereWithIndex_LinqExt ()
		{
			// Whhich of the first 5 parents ( index runs from 0 ) are less than 30
			Assert.AreEqual (1, people.Where (( x, index ) => index <= 4 && x.Age < 30).Count ());
		}

		[Test()]
		public void WhereWithDrilled_LinqExt ()
		{
			// Which parents have any children
			Assert.AreEqual (5, people.Where (x => x.Children.Count () > 0).Count ());
		}

		[Test()]
		public void WhereWithDrilled_Linq ()
		{
			// Which parents have any children

			var count = (from p in people 
			             where p.Children.Count () > 0 
			             select p).Count ();

			Assert.AreEqual (5, count);
		}

	}
}

