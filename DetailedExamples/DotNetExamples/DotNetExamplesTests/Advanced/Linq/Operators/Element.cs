using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Linq.Tests
{
	[TestFixture()]
	public class Element
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void First_LinqExt ()
		{
			// First person ordered by name
			var samplePeople = people.OrderBy (x => x.Name).First ();
		
			Assert.AreEqual ("Dave", samplePeople.Name);
		}

		[Test()]
		public void FirstConditional_LinqExt ()
		{
			// First Females ordered by name
			var samplePeople = people.OrderByDescending (x => x.Name).First (x => x.Gender == Gender.Male);
		
			Assert.AreEqual ("Jullius", samplePeople.Name);
		}

		[Test()]
		public void FirstOrDefault_LinqExt ()
		{
			// First OR Default of a .where with no returned records
			var samplePeople = people.Where (x => x.Name == "No Match").FirstOrDefault ();
			Assert.IsNull(samplePeople);
		}

		[Test()]
		public void FirstOrDefaultConditional_LinqExt ()
		{
			// First Or Default of a conditional with no return recoords
			Assert.IsNull (people.FirstOrDefault (x => x.Gender == Gender.Unknown));
		}

		[Test()]
		public void ElementAt_LinqExt ()
		{
			// First person (element 0) ordered by name
			var samplePeople = people.OrderBy (x => x.Name).ElementAt (0);
		
			Assert.AreEqual ("Dave", samplePeople.Name);
		}
	}
}