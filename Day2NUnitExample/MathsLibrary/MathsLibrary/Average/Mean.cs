//-----------------------------------------------------------------------
// <copyright file="Mean.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace MathsLibrary.Average
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Mean calcuation
    /// </summary>
    public class Mean
    {
        /// <summary>
        /// Calculate the specified  meandata.
        /// </summary>
        /// <param name='data'>
        /// Data to have the mean calculated
        /// </param>
        /// <returns>Mean value</returns>
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

            return data.Sum() / data.Count;
        }
    }
}