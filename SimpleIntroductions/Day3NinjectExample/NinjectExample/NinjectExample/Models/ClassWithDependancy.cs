//-----------------------------------------------------------------------
// <copyright file="ClassWithDependancy.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Models
{
    using System;
    using NinjectExample.Interfaces;

    /// <summary>
    /// Class with dependancy.
    /// </summary>
    public class ClassWithDependancy : IClassWithDependancy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectExample.Models.ClassWithDependancy"/> class.
        /// </summary>
        /// <param name='simpleClass'>
        /// Simple class.
        /// </param>
        public ClassWithDependancy(ISimpleClass simpleClass)
        {
            this.SimpleClass = simpleClass;
        }

        /// <summary>
        /// Gets the simple class
        /// </summary>
        /// <value>
        /// The simple class.
        /// </value>
        public ISimpleClass SimpleClass { get; private set; }

        /// <summary>
        /// Whos the am i.
        /// </summary>
        /// <returns>
        /// I dentifer
        /// </returns>
        public string WhoAmI()
        {
            return string.Format("ClassWithDependancy of {0}", this.SimpleClass.WhoAmI());
        }
    }
}