using System;
using System.Collections.Generic;

namespace LinqExamples
{
	public class PersonSexComparer : IEqualityComparer<Person>
	{ 
		public bool Equals (Person x, Person y)
		{ 
			return x.Gender == y.Gender;
		}
	      
		public int GetHashCode (Person obj)
		{ 
			return obj.Gender.GetHashCode (); 
		}     
	        
	}
}

