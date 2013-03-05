//-----------------------------------------------------------------------
// <copyright file="SimpleClassAlso.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Models
{
    using System;
    using NinjectExample.Interfaces;

    /// <summary>
    /// Simple class also.
    /// </summary>
    public class SimpleClassAlso : ISimpleClass
    {
        /// <summary>
        ///  Whos the am i. 
        /// </summary>
        /// <returns>
        ///  The am i. 
        /// </returns>
        public string WhoAmI()
        {
            return "SimpleClassAlso";
        }   
    }
}