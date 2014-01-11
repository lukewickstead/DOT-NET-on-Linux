using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Linq.Tests
{
	[TestFixture()]
	public class Partitioning
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void Take_LinqExt ()
		{
			// Taxes the first 3 people.
			var firstThreePeople = people.Take (3);
			Assert.AreEqual (3, firstThreePeople.Count ());
			Assert.AreEqual ("Jane", firstThreePeople.Last ().Name);
		}

		[Test()]
		public void NestedTake_LinqExt ()
		{
			// Take the first 2 males.
			var firstTwoPeople = people.Where (x => x.Gender == Gender.Male).Take (2);
			Assert.AreEqual (2, firstTwoPeople.Count ());
			Assert.AreEqual ("John", firstTwoPeople.First ().Name);
			Assert.AreEqual ("James", firstTwoPeople.Last ().Name);
		}
		
		[Test()]
		public void NestedTake_Linq ()
		{
			// Take the first 2 males.
			var firstTwoPeople = 
				(from p in people
				  where p.Gender == Gender.Male 
				  select new { p.Name, p.Age, p.Gender, p.Children }).Take (2); 
	
			Assert.AreEqual (2, firstTwoPeople.Count ());
			Assert.AreEqual ("John", firstTwoPeople.First ().Name);
			Assert.AreEqual ("James", firstTwoPeople.Last ().Name);
		}

		[Test()]
		public void Skip_LinqExt ()
		{
			// Take all but the first 4 people
			var allButFirstFour = people.Skip (4);
			Assert.AreEqual (3, allButFirstFour.Count ());
			Assert.AreEqual ("Jullius", allButFirstFour.First ().Name);
			Assert.AreEqual ("George", allButFirstFour.Last ().Name);
		}

		[Test()]
		public void TakeWhile_LinqExt ()
		{
			// Take only the first males.
			var allButFirstFour = people.TakeWhile (x => x.Gender == Gender.Male);
			Assert.AreEqual (2, allButFirstFour.Count ());
			Assert.AreEqual ("John", allButFirstFour.First ().Name);
			Assert.AreEqual ("James", allButFirstFour.Last ().Name);
		}

		[Test()]
		public void SkipWhile_LinqExt ()
		{
			// Take all but the first group of males.
			var allButFirstFour = people.SkipWhile (x => x.Gender == Gender.Male);
			Assert.AreEqual (5, allButFirstFour.Count ());
			Assert.AreEqual ("Jane", allButFirstFour.First ().Name);
			Assert.AreEqual ("George", allButFirstFour.Last ().Name);
		}
	}
}