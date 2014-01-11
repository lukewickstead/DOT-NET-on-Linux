using System;
using System.Linq;
using System.Collections.Generic;

namespace Advanced.Generics
{
	public class MeanCalculator
	{

		/// <summary>
		/// Calculate the 'Mean' Average of the collection of numbers.
		/// </summary>
		/// <param name='numbers'>
		/// Collection of numbers requiring Meaning
		/// </param>
		/// <typeparam name='T'>
		/// The 1st type parameter. Must be a number
		/// </typeparam>
		public static decimal Calculate<T> (IList<T> numbers) where T : struct
		{
			if (numbers == null)
				throw new ArgumentNullException ("numbers", "Can not calculate mean for null");
			if (numbers.Count == 0)
				throw new ArgumentException ("Empty collection found", "numbers");
			if (!IsNumber (numbers.First ()))
				throw new ArgumentException ("Collection of non numbers found", "numbers");

			return numbers.Sum<T> (x => Convert.ToDecimal (x)) / numbers.Count;		
		}

		private static bool IsNumber<T> (T number) where T :struct
		{
			var type = Type.GetTypeCode (typeof(T));

			return type == TypeCode.Decimal || type == TypeCode.Double || type == TypeCode.Int32; // etc
		}
	}
}

