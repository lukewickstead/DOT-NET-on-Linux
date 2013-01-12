using System;
using System.Collections.Generic;

namespace LinqExamples
{
	public class SampleDataProvider
	{
		public static IEnumerable<Person> GetSampleData ()
		{
			var people = new List<Person> ();

			people.Add (
				GetPerson ("John", 35, Gender.Male, 
			    	new List<Person> (){ 
						GetPerson( "Billy", 8, Gender.Male),
						GetPerson( "Emily", 6, Gender.Female)}
			)
			);

			people.Add (
				GetPerson ("James", 45, Gender.Male, 
			    	new List<Person> (){ 
						GetPerson( "Simon", 18, Gender.Male),
						GetPerson( "Johnny", 16, Gender.Female)}
			)
			);

			people.Add (
				GetPerson ("Jane", 55, Gender.Female, 
			    	new List<Person> (){ 
						GetPerson( "Peter", 16, Gender.Male),
						GetPerson( "Paul", 20, Gender.Male)}
			)
			);


			people.Add (
				GetPerson ("Sara", 45, Gender.Female, 
			    	new List<Person> (){ 
						GetPerson( "Sally", 18, Gender.Female),
						GetPerson( "Tilly", 16, Gender.Female),
						GetPerson( "Fredrica", 16, Gender.Female) }
			)
			);


			people.Add (GetPerson ("Jullius", 21, Gender.Male)); 
			people.Add (GetPerson ("Dave", 23, Gender.Male)); 
			people.Add (GetPerson ("George", 25, Gender.Male, new List<Person>(){ GetPerson ("George", 25, Gender.Unknown)})); 

			return people;					
		}

		private static Person GetPerson (string name, int age, Gender sex, IEnumerable<Person> children)
		{
			return new Person{ Name = name, Age = age, Gender = sex, Children = children};
		}

		private static Person GetPerson (string name, int age, Gender sex)
		{
			return GetPerson (name, age, sex, new List<Person> ());
		}

		public static IEnumerable<GenderDescriptor> GetGenderDescirptors()
		{		
			var maleDesc = new GenderDescriptor(){ Gender = Gender.Male, Descripion = "Adam"};
			var femaleDesc = new GenderDescriptor(){ Gender = Gender.Female, Descripion = "Eve"};
			var unknownDesc = new GenderDescriptor(){ Gender = Gender.Unknown, Descripion = "ET"};

			return new List<GenderDescriptor>(){ maleDesc, femaleDesc, unknownDesc }; 
		}		
	}
}

