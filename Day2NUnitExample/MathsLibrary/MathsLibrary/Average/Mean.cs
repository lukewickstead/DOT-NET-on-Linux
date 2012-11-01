using System;
using System.Linq;
using System.Collections.Generic;

namespace MathsLibrary.Average
{
	public class Mean
	{
		public static decimal Calculate(List<decimal> data)
		{
			if ( data == null  )
				throw new ArgumentNullException();

			if ( data.Count == 0 )
				throw new ArgumentException("No data provided");

			return data.Sum() / data.Count;
		}
	}
}

