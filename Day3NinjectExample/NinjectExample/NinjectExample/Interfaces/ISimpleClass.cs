//-----------------------------------------------------------------------
// <copyright file="ISimpleClass.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Interfaces
{
    using System;

    /// <summary>
    /// I simple class.
    /// </summary>
    public interface ISimpleClass
    {
        /// <summary>
        /// Whos the am i.
        /// </summary>
        /// <returns>
        /// The am i.
        /// </returns>
        string WhoAmI();
    }
}