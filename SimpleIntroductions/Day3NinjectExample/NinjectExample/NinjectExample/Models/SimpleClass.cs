//-----------------------------------------------------------------------
// <copyright file="SimpleClass.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Models
{
    using System;
    using NinjectExample.Interfaces;

    /// <summary>
    /// Simple class.
    /// </summary>
    public class SimpleClass : ISimpleClass
    {
        /// <summary>
        ///  Whos the am i. 
        /// </summary>
        /// <returns>
        ///  The am i. 
        /// </returns>
        public string WhoAmI()
        {
            return "SimpleClass";
        }   
    }
}