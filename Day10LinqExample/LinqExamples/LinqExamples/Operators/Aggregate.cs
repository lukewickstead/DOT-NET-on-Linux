using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Aggregate
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void Count_LinqExt ()
		{
			// Count
			var count = people.Count ();		
			Assert.AreEqual (7, count);
		}

		[Test()]
		public void Count_Linq ()
		{
			// Count - makes more sense to use the ext method
			var count = (from p in people 
						 select p).Count ();		
			Assert.AreEqual (7, count);
		}

		[Test()]
		public void CountConditions_LinqExt ()
		{
			// Count
			var count = people.Count (x => x.Gender == Gender.Male);		
			Assert.AreEqual (5, count);
		}

		[Test()]
		public void CountConditions_Linq ()
		{
			// Count
			var count = (from p in people
			             where p.Gender == Gender.Male
			             select p).Count ();

			Assert.AreEqual (5, count);
		}

		[Test()]
		public void CountNested_LinqExt ()
		{
			// Nested count peoples daughters
			var samplePeople = people.Select 
				(x => new { Name = x.Name, ChildrenCount = x.Children.Count (y => y.Gender == Gender.Female)});

			Assert.AreEqual (3, samplePeople.Where (x => x.Name == "Sara").First ().ChildrenCount);
			Assert.AreEqual (1, samplePeople.Where (x => x.Name == "James").First ().ChildrenCount);
			Assert.AreEqual (0, samplePeople.Where (x => x.Name == "Jane").First ().ChildrenCount);		
		}

		[Test()]
		public void CountNested_Linq ()
		{
			// Nested count peoples daughters
			var samplePeople = from p in people
							   select new { Name= p.Name, ChildrenCount = 
									  (from c in p.Children
				                 	  where c.Gender == Gender.Female
				                 	  select c).Count () };
	
			Assert.AreEqual (3, samplePeople.Where (x => x.Name == "Sara").First ().ChildrenCount);
			Assert.AreEqual (1, samplePeople.Where (x => x.Name == "James").First ().ChildrenCount);
			Assert.AreEqual (0, samplePeople.Where (x => x.Name == "Jane").First ().ChildrenCount);		
		}

		[Test()]
		public void CountGrouped_LinqExt ()
		{
			// Nested count peoples daughters
			var samplePeople = people.Select 
				(x => new { Name = x.Name, ChildrenCount = x.Children.Count (y => y.Gender == Gender.Female)});

			Assert.AreEqual (3, samplePeople.Where (x => x.Name == "Sara").First ().ChildrenCount);
			Assert.AreEqual (1, samplePeople.Where (x => x.Name == "James").First ().ChildrenCount);
			Assert.AreEqual (0, samplePeople.Where (x => x.Name == "Jane").First ().ChildrenCount);		
		}

		[Test()]
		public void Sum_LinqExt ()
		{
			// Sum  number of children.
			var childrenCount = people.Sum (x => x.Children.Count ()); 
			Assert.AreEqual (10, childrenCount);
		}

		[Test()]
		public void SumConditionals_LinqExt ()
		{
			// Number of Father's sons.
			var maleSonsCount = people.Where (x => x.Gender == Gender.Male).Sum (x => x.Children.Where (y => y.Gender == Gender.Male).Count ()); 
			Assert.AreEqual (2, maleSonsCount);
		}

		[Test()]
		public void Min_LinqExt ()
		{
			// Min number of children to parent.
			var minChildrenCount = people.Min (x => x.Children.Count ());
			Assert.AreEqual (0, minChildrenCount);
		}

		
		[Test()]
		public void Min_Linq ()
		{
			// Parent with min numbwr of children grouped by gender
			var children = from p in people 
				group p by p.Gender into peopleGenders
					let minKids = peopleGenders.Min( x => x.Children.Count())
				select new { Gender = peopleGenders.Key, Value = peopleGenders.Count() };


			Assert.AreEqual (5, children.Where( x => x.Gender == Gender.Male).FirstOrDefault().Value);
			Assert.AreEqual (2, children.Where( x => x.Gender == Gender.Female).FirstOrDefault().Value);
		}

		[Test()]
		public void Max_LinqExt ()
		{
			// Max number of children to parent.
			var maxChildrenCount = people.Max (x => x.Children.Count ());
			Assert.AreEqual (3, maxChildrenCount);
		}

		[Test()]
		public void Average_LinqExt ()
		{
			// Average number of chdilrens.
			var avgChildrenCount = people.Average (x => x.Children.Count ());
			Assert.AreEqual (1.43, Math.Round (avgChildrenCount, 2));
		}

		[Test()]
		public void MinMaxGrouped_LinqExt ()
		{
			// Min and Max number of childen grouped by gender
			var samplePeople = people.GroupBy (x => x.Gender).
				Select (y => new { Key = y.Key, 
					Average = Math.Round (y.Average (z => z.Children.Count ()), 2),
					Min = y.Min (z => z.Children.Count ()),
					Max = y.Max (z => z.Children.Count ())}
			);			

			Assert.AreEqual (2, samplePeople.Count ());
			Assert.AreEqual (2.5m, samplePeople.Where (x => x.Key == Gender.Female).FirstOrDefault ().Average);
			Assert.AreEqual (2, samplePeople.Where (x => x.Key == Gender.Female).FirstOrDefault ().Min);
			Assert.AreEqual (3, samplePeople.Where (x => x.Key == Gender.Female).FirstOrDefault ().Max);
			Assert.AreEqual (1.0m, samplePeople.Where (x => x.Key == Gender.Male).FirstOrDefault ().Average);
			Assert.AreEqual (0, samplePeople.Where (x => x.Key == Gender.Male).FirstOrDefault ().Min);
			Assert.AreEqual (2, samplePeople.Where (x => x.Key == Gender.Male).FirstOrDefault ().Max);
		}
	}
}