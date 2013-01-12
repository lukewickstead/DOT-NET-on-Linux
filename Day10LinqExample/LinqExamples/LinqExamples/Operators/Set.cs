using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Set
	{
		private IEnumerable<Person> people;
		private IEnumerable<GenderDescriptor> genderDescriptions;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
			genderDescriptions = SampleDataProvider.GetGenderDescirptors();
		}

		[Test()]
		public void Distinct_LinqExt ()
		{
			// Distinct group of numbers

			var numbers = new List<int> (){ 1,1,2,2,3,4,5 };

			var distinctNumbers = numbers.Distinct ();

			Assert.AreEqual (5, distinctNumbers.Count ());
			Assert.AreEqual (1, distinctNumbers.First ());
			Assert.AreEqual (5, distinctNumbers.Last ());
		}

		
		[Test()]
		public void Distinct_Linq ()
		{
			// Distinct group of numbers
			var distinctNumbers = ( from p in people
			                        orderby p.Name
			                        select p.Name  ).Distinct();
		
			Assert.AreEqual (7, distinctNumbers.Count ());
			Assert.AreEqual ("Dave", distinctNumbers.First ());
			Assert.AreEqual ("Sara", distinctNumbers.Last ());
		}

		[Test()]
		public void DistinctWithEqualityComparer_LinqExt ()
		{
			// Distinct groups of sex
			var distinctSex = people.Distinct (new PersonSexComparer ()).
				OrderBy (x => x.Gender).Select (y => y.Gender);

			Assert.AreEqual (2, distinctSex.Count ());
			Assert.AreEqual (Gender.Male, distinctSex.First ());
			Assert.AreEqual (Gender.Female, distinctSex.Last ());
		}

		[Test()]
		public void DistinctWithEqualityComparer_Linq ()
		{
			// Distinct groups of sex
			var distinctSex = ( from p in people
			                   orderby p.Gender
			                   select p.Gender ).Distinct(); // -- could not get this to work.....new PersonSexComparer());
	
			Assert.AreEqual (2, distinctSex.Count ());
			Assert.AreEqual (Gender.Male, distinctSex.First ());
			Assert.AreEqual (Gender.Female, distinctSex.Last ());
		}


		[Test()]
		public void Union_LinqExt ()
		{
			// Union childen (flattened with select many) with parents

			var allPeople = people.Union (people.SelectMany (x => x.Children)).
				OrderByDescending (x => x.Gender).ThenBy (x => x.Name);

			Assert.AreEqual (17, allPeople.Count ());
			Assert.AreEqual (Gender.Female, allPeople.First ().Gender);
			Assert.AreEqual ("Emily", allPeople.First ().Name);
			Assert.AreEqual (Gender.Unknown, allPeople.Last ().Gender);
			Assert.AreEqual ("George", allPeople.Last ().Name);
		}

		[Test()]
		public void Union_Linq ()
		{
			// Union childen (flattened with select many) with parents
			var allPeople = people.Union ( from p in people 
			                  from c in p.Children
			                 select c);

			var orderedAllPeople = from p in allPeople 
					orderby p.Gender descending, p.Name
					select p;

			Assert.AreEqual (17, orderedAllPeople.Count ());
			Assert.AreEqual (Gender.Female, orderedAllPeople.First ().Gender);
			Assert.AreEqual ("Emily", orderedAllPeople.First ().Name);
			Assert.AreEqual (Gender.Unknown, orderedAllPeople.Last ().Gender);
			Assert.AreEqual ("George", orderedAllPeople.Last ().Name);
		}


		[Test()]
		public void Intersect_LinqExt ()
		{
			// Intersect; distinct union between two sets of data
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
			var groupInter = groupOne.Intersect (groupTwo).OrderBy (x => x);

			Assert.AreEqual (2, groupInter.Count ());
			Assert.AreEqual (4, groupInter.First ());
			Assert.AreEqual (5, groupInter.Last ());
		}

		[Test()]
		public void Intersect_Linq ()
		{
			// Intersect; distinct union between two sets of data
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
			var groupInter = from n in groupOne 
					where groupTwo.Contains(n) 
					select n;

			Assert.AreEqual (2, groupInter.Count ());
			Assert.AreEqual (4, groupInter.First ());
			Assert.AreEqual (5, groupInter.Last ());
		}

		[Test()]
		public void Except_LinqExt ()
		{
			// Except: all of groupOne except where in existance in groupTwo
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
			var groupExcept = groupOne.Except (groupTwo).OrderBy (x => x);

			Assert.AreEqual (3, groupExcept.Count ());
			Assert.AreEqual (1, groupExcept.First ());
			Assert.AreEqual (3, groupExcept.Last ());
		}

		[Test()]
		public void Except_Linq ()
		{
			// Except: all of groupOne except where in existance in groupTwo
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
			var groupExcept = from n in groupOne
				where !groupTwo.Contains(n)
					select n;

			Assert.AreEqual (3, groupExcept.Count ());
			Assert.AreEqual (1, groupExcept.First ());
			Assert.AreEqual (3, groupExcept.Last ());
		}


		[Test()]
		public void Concat_LinqExt ()
		{
			// Concat all elements
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
			var groupExcept = groupOne.Concat (groupTwo).OrderBy( x=> x);
		
			Assert.AreEqual (9, groupExcept.Count ());
			Assert.AreEqual (1, groupExcept.First ());
			Assert.AreEqual (7, groupExcept.Last ());
		}

		[Test()]
		public void Concat_Linq ()
		{
			// Concat all elements
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
			var groupOneQ = from g1 in groupOne select g1;
			var groupTwoQ = from g2 in groupTwo select g2;

			var groupBoth = groupOne.Concat(groupTwo);
			var groupBothOrdered = from g in groupBoth
								   orderby g
								   select g;		
		
			Assert.AreEqual (9, groupBothOrdered.Count ());
			Assert.AreEqual (1, groupBothOrdered.First ());
			Assert.AreEqual (7, groupBothOrdered.Last ());
		}

		[Test()]
		public void EqualAll_LinqExt ()
		{
			// All elements are equal and in the same order
			var groupOne = new List<int> (){ 1,2,3,4,5};
			var groupOneAgain = new List<int> (){ 1,2,3,4,5};
			var groupTwo = new List<int> (){4,5,6,7};
		
			Assert.AreEqual (groupOne, groupOneAgain);
			Assert.IsTrue (groupOne.SequenceEqual(groupOneAgain));
			Assert.IsFalse (groupOne.SequenceEqual(groupTwo));
		}

		[Test()]
		public void InnerJoin_LinqExt ()
		{
			// inner join between person and gender description
			var foo = people.Join( genderDescriptions, 
			                      aPerson => aPerson.Gender,  
			                      aDesc => aDesc.Gender, 	
			                      ( aPerson, aDes ) => new { Name = aPerson.Name, Gender = aPerson.Gender, Desc = aDes.Descripion} );

			Assert.AreEqual( "Eve", foo.First( x => x.Gender == Gender.Female).Desc);
			Assert.AreEqual( "Adam", foo.First( x => x.Gender == Gender.Male).Desc);
		}

		[Test()]
		public void InnerJoin_Linq ()
		{
			// inner join between person and gender description

			var foo = from aPerson in people
				join aDes in genderDescriptions on aPerson.Gender equals aDes.Gender  
			select new { Name = aPerson.Name, Gender = aPerson.Gender, Desc = aDes.Descripion};

			Assert.AreEqual( "Eve", foo.First( x => x.Gender == Gender.Female).Desc);
			Assert.AreEqual( "Adam", foo.First( x => x.Gender == Gender.Male).Desc);
		}
	}
}