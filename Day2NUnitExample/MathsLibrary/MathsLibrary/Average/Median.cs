using System;
using System.Linq;
using System.Collections.Generic;

namespace MathsLibrary.Average
{
	public class Median
	{
		public static decimal Calculate (List<decimal> data)
		{
			if (data == null)
				throw new ArgumentNullException ();

			if (data.Count == 0)
				throw new ArgumentException ("No data provided");

			data.Sort ();
		
			if (isEven (data.Count)) {
				return calculatWithEvenData (data);
			} else {
				return calculatWithOddData (data);
			}				
		}

		private static decimal calculatWithOddData (List<decimal> data)
		{

			var middlePosition = (decimal)data.Count / 2;

			--middlePosition; 

			return data [(int)Math.Ceiling ((decimal)middlePosition)];
		}
			
		private static decimal calculatWithEvenData (List<decimal> data)
		{

			var middlePosition = data.Count / 2;

			--middlePosition;		

			var lower = data [middlePosition];
			var upper = data [middlePosition + 1];

			return (lower + upper) / 2;
		}

		private static bool isEven (int count)
		{

			decimal divCheck = (decimal)count / 2;

			return (divCheck - Math.Floor (divCheck)) == 0;
		}

	}
}

