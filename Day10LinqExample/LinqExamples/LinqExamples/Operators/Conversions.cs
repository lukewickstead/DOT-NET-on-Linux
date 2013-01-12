using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace LinqExamples
{
	[TestFixture()]
	public class Conversion
	{
		private IEnumerable<Person> people;

		[SetUp]
		public void getTestData ()
		{
			people = SampleDataProvider.GetSampleData ();
		}

		[Test()]
		public void ToArray_LinqExt ()
		{
			// Order by Name asc and then convert to an Array
			var samplePeople = people.OrderBy (x => x.Name).ToArray ();
		
			Assert.AreEqual (7, samplePeople.Count ());
			Assert.IsInstanceOf (typeof(Array), samplePeople);
			Assert.AreEqual ("Dave", samplePeople [0].Name);
		}

		[Test()]
		public void ToList_LinqExt ()
		{
			// Convert to a List
			var samplePeople = people.ToList ();
		
			Assert.AreEqual (7, samplePeople.Count ());
			Assert.IsInstanceOf (typeof(List<Person>), samplePeople);
			Assert.AreEqual ("Dave", samplePeople.Find (x => x.Name.Equals ("Dave", StringComparison.CurrentCultureIgnoreCase)).Name);
		}

		[Test()]
		public void ToDictionary_LinqExt ()
		{
			// Convert to dictionary <String,Person> keyed on Name.
			var samplePeople = people.ToDictionary (x => x.Name);
		
			Assert.AreEqual (7, samplePeople.Count ());
			Assert.IsInstanceOf (typeof(Dictionary<String,Person>), samplePeople);
			Assert.AreEqual (7, samplePeople.Keys.Count);
			Assert.AreEqual (true, samplePeople.Keys.Contains ("Dave"));
			Assert.AreEqual (Gender.Male, samplePeople ["Dave"].Gender);
			Assert.AreEqual (false, samplePeople.Keys.Contains ("Emily"));
		}

		[Test()]
		public void OfType_LinqExt ()
		{
			// Filter out those which are note od typw double
			var sampleIntNumbers = new List<object> (){ 1,2,3,4,5,6m,7,8m,9,10};
			var sampleDecimalNumbers = sampleIntNumbers.OfType<decimal> ().ToList ();

			Assert.AreEqual (2, sampleDecimalNumbers.Count ());
	
			Assert.IsInstanceOf (typeof(List<decimal>), sampleDecimalNumbers);
			Assert.IsInstanceOf (typeof(decimal), sampleDecimalNumbers.First ());
		}

		[Test()]
		public void Cast_LinqExt ()
		{
			// Cast can only cast to Implemented Interfaces and classes within the hierachy
			// Convert all data ti 
			var sampleObjNumbers = new List<object> (){ 1,2,3,4,5,6,7,8,9,10};
			var sampleIntNumbers = sampleObjNumbers.Cast<int> ().ToList ();

			Assert.AreEqual (10, sampleIntNumbers.Count ());
			Assert.IsInstanceOf (typeof(List<int>), sampleIntNumbers);
			Assert.IsInstanceOf (typeof(int), sampleIntNumbers.First ());
		}

		[Test()]
		public void ConvertAll_LinqExt ()
		{
			// Convert list of ints into list of doubles.
			var sampleObjNumbers = new List<int> (){ 1,2,3,4,5,6,7,8,9,10};
			var sampleIntNumbers = sampleObjNumbers.ConvertAll<double> (x => Convert.ToDouble (x));

			Assert.AreEqual (10, sampleIntNumbers.Count ());
			Assert.IsInstanceOf (typeof(List<double>), sampleIntNumbers);
			Assert.IsInstanceOf (typeof(double), sampleIntNumbers.First ());
		}

		[Test()]
		public void ConvertAllAgain_LinqExt ()
		{
			// Convert all strings to Upper Case 			
			var upperCaseNames = people.Select (x => x.Name).OrderBy (x => x).ToList ().ConvertAll<string> (x => x.ToUpper ());

			Assert.AreEqual ("DAVE", upperCaseNames.First ());
			Assert.AreNotEqual ("Dave", upperCaseNames.First ());
		}
	}
}