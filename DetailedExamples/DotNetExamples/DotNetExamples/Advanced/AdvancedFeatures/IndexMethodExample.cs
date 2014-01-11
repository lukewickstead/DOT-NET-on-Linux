using System;
using System.Linq;
using System.Collections.Generic;

namespace Advanced.AdvancedFeatures
{
	public class IntIndexedClass
	{
		private Dictionary<int, string> data = new Dictionary<int,String> ();

		public string this [int index] {     
			get { 
				if (data.ContainsKey (index)) {
					return data [index];
				} else {
					return string.Empty;
				}
			}
			set { data [index] = value; }   
		}
	}

	public class StringIndexedClass
	{
		private Dictionary<string, string> data = new Dictionary<string,String> (StringComparer.InvariantCultureIgnoreCase);

		public string this [string index] {     
			get { 
				if (data.ContainsKey (index)) {
					return data [index];
				} else {
					return string.Empty;
				}
			}
			set { data [index] = value; }   
		}
	}

	public class DblIntIndexedClass
	{
		private int[,] data = new int[3, 3];

		public int this [int x, int y] {     
			get { return data [x, y]; }     
			set { data [x, y] = value; }   
		}
	}
}