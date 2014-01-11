//-----------------------------------------------------------------------
// <copyright file="Mode.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace MathsLibrary.Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Mode Average
    /// </summary>
    public class Mode
    {
        /// <summary>
        /// Calculate the mode average
        /// </summary>
        /// <param name='data'>
        /// Data to be averages
        /// </param>
        /// <returns>Mode average</returns>
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

            var occuranceCount = CountOccurances(data);
            var maxOccurance = occuranceCount.Max(x => x.Value);
            var valueWithMaxOccurance = occuranceCount.Where(x => x.Value == maxOccurance).Select(x => x.Key);

            if (valueWithMaxOccurance.ToList().Count > 1)
            {
                throw new NotImplementedException("We have not quite got around to  Mode with grouping...");
            }

            return valueWithMaxOccurance.First();
        }

        /// <summary>
        /// Counts the occurances.
        /// </summary>
        /// <returns>
        /// Dictionary of element vs occurance count
        /// </returns>
        /// <param name='data'>
        /// Data being analysed
        /// </param>
        /// <returns>Dictionary of occurances of elements</returns>
        private static Dictionary<decimal, int> CountOccurances(List<decimal> data)
        {
            var counter = new Dictionary<decimal, int>();

            foreach (decimal value in data)
            {
                if (counter.ContainsKey(value))
                {
                    counter[value] += 1;
                }
                else
                {
                    counter[value] = 1;
                }
            }

            return counter;
        }
    }
}