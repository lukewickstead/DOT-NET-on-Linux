//-----------------------------------------------------------------------
// <copyright file="Median.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace MathsLibrary.Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Median calculator
    /// </summary>
    public class Median
    {
        /// <summary>
        /// Calculate the specified data.
        /// </summary>
        /// <param name='data'>
        /// Data to be averaged
        /// </param>
        /// <returns>Median data</returns>
        public static decimal Calculate(List<decimal> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            if (data.Count == 0)
            {
                throw new ArgumentException("No data provided");
            }

            data.Sort();

            if (IsEven(data.Count))
            {
                return CalculatWithEvenData(data);
            }
            else
            {
                return CalculatWithOddData(data);
            }
        }

        /// <summary>
        /// Calculats the median the with odd data elements.
        /// </summary>
        /// <returns>
        /// The with odd data.
        /// </returns>
        /// <param name='data'>
        /// Data to be averaged
        /// </param>
        /// <returns>Median data</returns>
        private static decimal CalculatWithOddData(List<decimal> data)
        {
            var middlePosition = (decimal)data.Count / 2;

            --middlePosition; 

            return data[(int)Math.Ceiling((decimal)middlePosition)];
        }

        /// <summary>Calculats the with even data.</summary>
        /// <returns>The with even data.</returns>
        /// <param name='data'>Data to be averaged</param>
        /// <returns>averaged data</returns>
        private static decimal CalculatWithEvenData(List<decimal> data)
        {
            var middlePosition = data.Count / 2;

            --middlePosition;

            var lower = data[middlePosition];
            var upper = data[middlePosition + 1];

            return (lower + upper) / 2;
        }

        /// <summary>Is the int even</summary>
        /// <returns>True/False is the count is event.</returns>
        /// <param name='count'>Element being analysed</param>
        private static bool IsEven(int count)
        {
            decimal divCheck = (decimal)count / 2;

            return (divCheck - Math.Floor(divCheck)) == 0;
        }
    }
}