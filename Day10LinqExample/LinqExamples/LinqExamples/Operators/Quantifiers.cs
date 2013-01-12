using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Quantifiers
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void Any_LinqExt ()
		{
			// Any exists?
			var isAnyPeople = people.Any (x => x.Gender == Gender.Unknown);

			Assert.IsFalse (isAnyPeople);
		}

		[Test()]
		public void Any_Linq ()
		{
			// Any exists?
			var isAnyPeople = (from p in people 
			                   where p.Gender == Gender.Unknown 
			                   select p).Any (); 

			Assert.IsFalse (isAnyPeople);
		}

		[Test()]
		public void AnyGrouped_Linq ()
		{
			// Any exists in group
			var isAnyPeople = from p in people
			    			  where p.Children.Any (child => child.Gender == Gender.Unknown)							         
							  group p by p.Gender into genders
			                  select new { Gender = genders.Key, People = genders};
		
			Assert.IsFalse (isAnyPeople.Any (x => x.Gender == Gender.Female));
			Assert.IsTrue (isAnyPeople.Any (x => x.Gender == Gender.Male));	
		}

		[Test()]
		public void AnyGrouped_LinqExt ()
		{
			// Any exists in groups
			var isAnyPeople = 
				people.Where (z => z.Children.Any (child => child.Gender == Gender.Unknown)).
			                GroupBy (x => x.Gender).
							Select (y => new { Gender = y.Key, People = y });


			Assert.IsFalse (isAnyPeople.Any (x => x.Gender == Gender.Female));
			Assert.IsTrue (isAnyPeople.Any (x => x.Gender == Gender.Male));
		}

		[Test()]
		public void All_LinqExt ()
		{
			// All meet criteria
			var allMale = people.All (x => x.Gender == Gender.Male);
			var allGenderKnown = people.All (x => x.Gender != Gender.Unknown);

			Assert.False (allMale);
			Assert.True (allGenderKnown);
		}

		[Test()]
		public void AllGrouped_Linq ()
		{

			var isAll = from p in people
				group p by p.Gender into genders
				where genders.All( x => x.Children.All (child => child.Gender == Gender.Female))							         
				select new { Gender = genders.Key, Value = genders};
		

			foreach (var x in isAll) { 	var y = x; }

			//Assert.AreEqual (1, isAll.Where (x => x.Gender == Gender.Female).Select (x => x.Count));
			Assert.AreEqual (1, isAll.Where (x => x.Gender == Gender.Male).Select (y => y.Value));
			Assert.AreEqual (2, isAll.Where (x => x.Gender == Gender.Female).Select (y => y.Value));

		

			// All meet criteria
			//var allMale = people.All (x => x.Gender == Gender.Male);
			//var allGenderKnown = people.All (x => x.Gender != Gender.Unknown);

			//Assert.False (allMale);
			//Assert.True (allGenderKnown);
		}

//		[Test()]
//		public void All_Linq ()
//		{
//			// All meet criteria
//			var allMale = (from p in people
//						    where p.All (y => y == Gender.Male)
//			                select p).Count () > 0;
//
//			var allGenderKnown = (from p in people
//						    	   where p.All (y => y.Gender != Gender.Unknown)
//			                	   select p).Count () > 0;
//
//			Assert.False (allMale);
//			Assert.True (allGenderKnown);
//		}
	}
}