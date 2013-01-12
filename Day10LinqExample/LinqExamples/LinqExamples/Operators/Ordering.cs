using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Ordering
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void OrderBy_LinqExt ()
		{
			// Order by.
			var orderdPeople = people.OrderBy (x => x.Name);
		
			Assert.AreEqual ("Dave", orderdPeople.First ().Name);
			Assert.AreEqual ("Sara", orderdPeople.Last ().Name);
		}

		[Test()]
		public void OrderBy_Linq ()
		{
			// Order by.
			var orderdPeople = from p in people
				orderby p.Name
				select new { p.Name, p.Age, p.Children, p.Gender };

			Assert.AreEqual ("Dave", orderdPeople.First ().Name);
			Assert.AreEqual ("Sara", orderdPeople.Last ().Name);
		}

		[Test()]
		public void OrderByStringCaseInsative_LinqExt ()
		{
			// Order by with case insensative equality compariions
			var orderdPeople = people.OrderBy (x => x.Name, StringComparer.CurrentCultureIgnoreCase);
			Assert.AreEqual ("Dave", orderdPeople.First ().Name);
			Assert.AreEqual ("Sara", orderdPeople.Last ().Name);
		}

		[Test()]
		public void OrderByDesc_LinqExt ()
		{
			// Desceding Order
			var orderdPeople = people.OrderByDescending (x => x.Name);
			Assert.AreEqual ("Sara", orderdPeople.First ().Name);
			Assert.AreEqual ("Dave", orderdPeople.Last ().Name);
		}

		[Test()]
		public void OrderByDesc_Linq ()
		{
			// Desceding Order
			var orderdPeople = from p in people
				orderby p.Name descending 
				select new { p.Name, p.Age, p.Gender, p.Children };

			Assert.AreEqual ("Sara", orderdPeople.First ().Name);
			Assert.AreEqual ("Dave", orderdPeople.Last ().Name);
		}

		[Test()]
		public void OrderByThenBy_LinqExt ()
		{
			// Multiple order by criteria
			var orderdPeople = people.OrderBy (x => x.Age).ThenByDescending (x => x.Name);
			Assert.AreEqual ("Jullius", orderdPeople.First ().Name);
			Assert.AreEqual (21, orderdPeople.First ().Age);
			Assert.AreEqual ("Jane", orderdPeople.Last ().Name);
			Assert.AreEqual (55, orderdPeople.Last ().Age);	
		}

		[Test()]
		public void OrderByThenBy_Linq ()
		{
			// Multiple order by criteria
			var orderdPeople = from p in people 
				orderby p.Age, p.Name descending
				select new { p.Name, p.Age, p.Gender, p.Children };

			Assert.AreEqual ("Jullius", orderdPeople.First ().Name);
			Assert.AreEqual (21, orderdPeople.First ().Age);
			Assert.AreEqual ("Jane", orderdPeople.Last ().Name);
			Assert.AreEqual (55, orderdPeople.Last ().Age);	
		}

		[Test()]
		public void Reverse_LinqExt ()
		{
			// Reverses the order of.
			var orderdPeople = people.OrderBy (x => x.Name).Reverse ();
			Assert.AreEqual ("Dave", orderdPeople.Last ().Name);
			Assert.AreEqual ("Sara", orderdPeople.First ().Name);
		}

		[Test()]
		public void Reverse_Linq ()
		{
			// Reverses the order of.
			var orderdPeople = (from p in people
				orderby p.Name
			    select new { p.Name, p.Age, p.Gender, p.Children }).Reverse ();

			Assert.AreEqual ("Dave", orderdPeople.Last ().Name);
			Assert.AreEqual ("Sara", orderdPeople.First ().Name);
		}


	}
}