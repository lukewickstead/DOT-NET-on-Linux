//-----------------------------------------------------------------------
// <copyright file="IClassWithDependancy.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Interfaces
{
    using System;

    /// <summary>
    /// I class with dependancy.
    /// </summary>
    public interface IClassWithDependancy
    {
        /// <summary>Gets the simple class</summary>
        /// <value>The simple class.</value>
        ISimpleClass SimpleClass { get; }

        /// <summary>Whos the am i.</summary>
        /// <returns>I dentifer</returns>
        string WhoAmI();
    }
}