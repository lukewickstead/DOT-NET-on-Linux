using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Advanced.Linq.Tests
{
	[TestFixture()]
	public class Projection
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void Select_LinqExt ()
		{
			// Select all names
			var allFemaleNames = people.Where (x => x.Gender == Gender.Female).Select (x => x.Name);
			Assert.AreEqual (2, allFemaleNames.Count ());
			Assert.AreEqual ("Sara", allFemaleNames.OrderByDescending (x => x).First ());
		}

		[Test()]
		public void Select_Linq ()
		{
			// Select all names
			var allFemaleNames = from p in people 
			           			where p.Gender == Gender.Female
			           			orderby p.Name descending
								select p.Name;

			Assert.AreEqual (2, allFemaleNames.Count ());
			Assert.AreEqual ("Sara", allFemaleNames.First ());
		}

		[Test()]
		public void SelectWithAnonymous_LinqExt ()
		{
			// Select all people into a list and then filter by Sex
			var parentsNameAndAge = people.Where (x => x.Gender == Gender.Female).Select (x => new { Name = x.Name, Age = x.Age });

			Assert.AreEqual (55, parentsNameAndAge.First ().Age);
			Assert.AreEqual ("Jane", parentsNameAndAge.First ().Name);
		}

		[Test()]
		public void SelectWithAnonymous_Linq ()
		{
			// Select all people into a list and then filter by Sex
			var parentsNameAndAge = from p in people
				where p.Gender == Gender.Female 
				select new { Name =  p.Name, Age = p.Age };
	
			Assert.AreEqual (55, parentsNameAndAge.First ().Age);
			Assert.AreEqual ("Jane", parentsNameAndAge.First ().Name);
		}

		[Test()]
		public void SelectWithMulitpleFrom_LinqExt ()
		{
			// All boys with female parents
			var boysWithFemaleParents = people.Where (x => x.Gender == Gender.Female).
				SelectMany (x => x.Children).
					Where (x => x.Gender == Gender.Male);

			Assert.AreEqual (2, boysWithFemaleParents.Count ());
			Assert.AreEqual ("Peter", boysWithFemaleParents.ElementAt (0).Name);
			Assert.AreEqual ("Paul", boysWithFemaleParents.ElementAt (1).Name);		
		}

		[Test()]
		public void SelectWithMulitpleFrom_Linq ()
		{
			// All boys with female parents
			var boysWithFemaleParents = from parent in people
				where parent.Gender == Gender.Female 
				from children in parent.Children 
				where children.Gender == Gender.Male 
				select children;

			Assert.AreEqual (2, boysWithFemaleParents.Count ());
			Assert.AreEqual ("Peter", boysWithFemaleParents.ElementAt (0).Name);
			Assert.AreEqual ("Paul", boysWithFemaleParents.ElementAt (1).Name);		
		}

		[Test()]
		public void SelectMany_LinqExt ()
		{
			// Select all people into a list and then filter by Sex
			Assert.AreEqual (9, people.SelectMany (x => x.AllPeople).Where (x => x.Gender == Gender.Male).Count ());
		}
	}
}