//-----------------------------------------------------------------------
// <copyright file="ClassWithConstructorParameters.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample.Models
{
    using System;
    using NinjectExample.Interfaces;

    /// <summary>
    /// Class with constructor parameters.
    /// </summary>
    public class ClassWithConstructorParameters : IClassWithConstructorParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectExample.Models.ClassWithConstructorParameters"/> class.
        /// </summary>
        /// <param name='messageOne'>
        /// Message one.
        /// </param>
        /// <param name='messageTwo'>
        /// Message two.
        /// </param>
        public ClassWithConstructorParameters(string messageOne, string messageTwo)
        {
            this.MessageOne = messageOne;
            this.MessageTwo = messageTwo;
        }

        /// <summary>
        /// Gets the message one.
        /// </summary>
        /// <value>
        /// The message one.
        /// </value>
        public string MessageOne { get; private set; }

        /// <summary>
        /// Gets the message two.
        /// </summary>
        /// <value>
        /// The message two.
        /// </value>
        public string MessageTwo { get; private set; }    

        /// <summary>
        ///  Whos the am i. 
        /// </summary>
        /// <returns>
        /// I dentifier 
        /// </returns>
        public string WhoAmI()
        {
            return string.Format("ClassWithConstructorParameters with messageOne:{0} and messageTwo:{1}", this.MessageOne, this.MessageTwo);
        }
    }
}