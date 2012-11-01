using System;
using System.Collections.Generic;
using System.Linq;

namespace MathsLibrary.Average
{
	public class Mode
	{

		public static decimal Calculate (List<decimal> data)
		{
			if (data == null)
				throw new ArgumentNullException ();

			if (data.Count == 0)
				throw new ArgumentException ("No data provided");


			var occuranceCount = countOccurances (data);
			var maxOccurance = occuranceCount.Max (x => x.Value);
			var valueWithMaxOccurance = occuranceCount.Where (x => x.Value == maxOccurance).Select (x => x.Key);

			if (valueWithMaxOccurance.ToList ().Count > 1) {
				throw new NotImplementedException ("We have not quite got around to  Mode with grouping...");
			}

			return valueWithMaxOccurance.First ();
		}

		static Dictionary<decimal, int>  countOccurances (List<decimal> data)
		{

			var counter = new Dictionary<decimal, int> ();

			foreach (decimal value in data) {

				if (counter.ContainsKey (value)) {

					counter [value] += 1;
				} else {

					counter [value] = 1;
				}
			}

			return counter;
		}
	}
}

