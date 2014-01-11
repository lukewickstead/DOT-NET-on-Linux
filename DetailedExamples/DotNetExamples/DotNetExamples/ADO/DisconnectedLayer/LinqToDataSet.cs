using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace ADO.DisconnectedLayer
{
	public class LinqToDataSet
	{
		DataTable DT = new DataTable ();

		public LinqToDataSet ()
		{
			DT.Columns.Add (new DataColumn ("Name", typeof(String)));
			DT.Columns.Add (new DataColumn ("Age", typeof(int)));

			AddRow ("Ivor", 34);
			AddRow ("John", 31);
			AddRow ("Fred", 33);
			AddRow ("Bob", 30);
			AddRow ("Peter", 32);
		}

		private void AddRow (string name, int age)
		{
			var aRow = DT.NewRow ();

			aRow ["Name"] = name;
			aRow ["Age"] = age;

			DT.Rows.Add (aRow);
		}

		public List<DataRow> SelectAll ()
		{
			var query = from row in DT.AsEnumerable ()
			            select row;

			return query.ToList ();
		}

		public List<DataRow> SelectBob ()
		{
			var query = DT.AsEnumerable ().Where (p => p.Field<string> ("Name") == "Bob");
		
			return query.ToList ();
		}

		public List<DataRow> SelectAllOrderByAgeDescending ()
		{
			var query = from p in DT.AsEnumerable ()
			orderby p.Field<int>("Age") descending
			            select p;

			return query.ToList ();
		}

		public int GetTotalAgeViaAnonymous ()
		{
			var asAnon = DT.AsEnumerable ().Select (p => new
			{
				Name = p.Field<string> ("Name"),
				Age = p.Field<int> ("Age")
			}).ToList ();

			return asAnon.Sum (x => x.Age);
		}
	}
}