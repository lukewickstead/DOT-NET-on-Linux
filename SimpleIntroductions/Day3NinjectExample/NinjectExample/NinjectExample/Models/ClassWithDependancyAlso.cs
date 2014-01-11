//-----------------------------------------------------------------------
// <copyright file="ClassWithDependancyAlso.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Models
{
    using System;
    using NinjectExample.Interfaces;

    /// <summary>
    /// Class with dependancy also.
    /// </summary>
    public class ClassWithDependancyAlso
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectExample.Models.ClassWithDependancyAlso"/> class.
        /// </summary>
        /// <param name='simpleClass'>
        /// Simple class.
        /// </param>
        public ClassWithDependancyAlso(ISimpleClass simpleClass)
        {
            this.SimpleClass = simpleClass;
        }

        /// <summary>
        /// Gets the simple class.
        /// </summary>
        /// <value>
        /// The simple class.
        /// </value>
        public ISimpleClass SimpleClass { get; private set; }

        /// <summary>
        /// Whos the am i.
        /// </summary>
        /// <returns>
        /// The am i.
        /// </returns>
        public string WhoAmI()
        {
            return string.Format("ClassWithDependancyAlso of {0}", this.SimpleClass.WhoAmI());
        }
    }
}
