//-----------------------------------------------------------------------
// <copyright file="IClassWithConstructorParameters.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Interfaces
{
    using System;

    /// <summary>
    /// I class with constructor parameters.
    /// </summary>
    public interface IClassWithConstructorParameters
    {
        /// <summary>
        /// Whos the am i.
        /// </summary>
        /// <returns>I dentifier </returns>
        string WhoAmI();
    }
}
