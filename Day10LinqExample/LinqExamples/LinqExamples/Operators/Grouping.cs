using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Grouping
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void GroupBy_LinqExt ()
		{
			// Group by gender and count...
			var samplePeople = people.GroupBy (x => x.Gender).OrderBy (x => x.Key).
				Select (grp => new { Key = grp.Key,  Value = grp.Count ()});

			Assert.AreEqual (2, samplePeople.Count ());

			Assert.AreEqual (Gender.Male, samplePeople.First ().Key);
			Assert.AreEqual (5, samplePeople.First ().Value);

			Assert.AreEqual (Gender.Female, samplePeople.Last ().Key);
			Assert.AreEqual (2, samplePeople.Last ().Value);
		}

		[Test()]
		public void GroupBy_Linq ()
		{
			// Group by gender and count...
			var samplePeople = from p in people 
				group p by p.Gender into gens
				select new { Key = gens.Key, Value = gens.Count()};
		
			Assert.AreEqual (2, samplePeople.Count ());

			Assert.AreEqual (Gender.Male, samplePeople.First ().Key);
			Assert.AreEqual (5, samplePeople.First ().Value);

			Assert.AreEqual (Gender.Female, samplePeople.Last ().Key);
			Assert.AreEqual (2, samplePeople.Last ().Value);
		}

		[Test()]
		public void GrouprBySelectInto_LinqExt ()
		{
			// Split into groups of gender by grouping on Name
			var samplePeople = people.GroupBy (x => x.Gender).OrderBy (x => x.Key).
				Select (grp => new { Key = grp.Key,  Value = grp.OrderBy (x => x.Name)});

			Assert.AreEqual (2, samplePeople.Count ());

			Assert.AreEqual (Gender.Male, samplePeople.First ().Key);
			Assert.AreEqual (5, samplePeople.First ().Value.Count ());
			Assert.AreEqual ("Dave", samplePeople.First ().Value.First ().Name);
			Assert.AreEqual ("Jullius", samplePeople.First ().Value.Last ().Name);

			Assert.AreEqual (Gender.Female, samplePeople.Last ().Key);
			Assert.AreEqual (2, samplePeople.Last ().Value.Count ());
			Assert.AreEqual ("Jane", samplePeople.Last ().Value.First ().Name);
			Assert.AreEqual ("Sara", samplePeople.Last ().Value.Last ().Name);			
		}

		[Test()]
		public void GrouprBySelectInto_Linq ()
		{
			// Split into groups of gender by grouping on Name
	
			var samplePeople = from p in people 
				group p by p.Gender into gens
				select new { Key = gens.Key, Value = gens.OrderBy( x => x.Name)};

			Assert.AreEqual (2, samplePeople.Count ());

			Assert.AreEqual (Gender.Male, samplePeople.First ().Key);
			Assert.AreEqual (5, samplePeople.First ().Value.Count ());
			Assert.AreEqual ("Dave", samplePeople.First ().Value.First ().Name);
			Assert.AreEqual ("Jullius", samplePeople.First ().Value.Last ().Name);

			Assert.AreEqual (Gender.Female, samplePeople.Last ().Key);
			Assert.AreEqual (2, samplePeople.Last ().Value.Count ());
			Assert.AreEqual ("Jane", samplePeople.Last ().Value.First ().Name);
			Assert.AreEqual ("Sara", samplePeople.Last ().Value.Last ().Name);			
		}

        [Test()]
        public void MultipleGroup()
        {
            var samplePeople = people.GroupBy (key => new { key.Gender, key.Age},
            (key, group ) => new { key.Gender, key.Age, Count = group.Count()});

            Assert.AreEqual (7, samplePeople.Count ());
        }
	}
}