using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced.Linq.Tests
{
	public class Person
	{
		public int Age { get; set; }

		public Gender Gender { get; set; }

		public string Name { get; set; }

		public IEnumerable<Person> Children { get; set; }

		private IEnumerable<Person> _allPeople;

		public Person ()
		{
			Children = new List<Person> ();
		}
	
		public IEnumerable<Person> AllPeople {
			get {
				if (_allPeople == null)
					_allPeople = GetAllPeople ();

				return _allPeople;
			}
		}

		private IEnumerable<Person> GetAllPeople ()
		{
			var allPeople = new List<Person> (Children);
			allPeople.Add (this);
			return allPeople;
		}
	}
}