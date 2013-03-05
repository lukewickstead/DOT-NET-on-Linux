//-----------------------------------------------------------------------
// <copyright file="Test.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExampleTests
{
    using System;
    using Ninject;
    using NinjectExample;
    using NinjectExample.Interfaces;
    using NinjectExample.Models;
    using NUnit.Framework;

    /// <summary>
    /// Test Class
    /// </summary>
    [TestFixture]
    public class Test
    {
        /// <summary>
        /// The kernel.
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// Init this instance.
        /// </summary>
        [TestFixtureSetUp]
        public void Init()
        {
            this.kernel = InjectionFactory.Instance.Kernel;
        }

        /// <summary>
        /// Determines whether this instance can test interface injection.
        /// </summary>
        [Test]
        public void CanTestInterfaceInjection()
        {
            var simpleClass = this.kernel.Get<ISimpleClass>();
            
            Assert.IsInstanceOf<SimpleClass>(simpleClass);
            Assert.AreEqual(simpleClass.WhoAmI(), "SimpleClass");
        }

        /// <summary>
        /// Determines whether this instance can test injection with dependancy.
        /// </summary>
        [Test]
        public void CanTestInjectionWithDependancy()
        {
            var classWithDep = this.kernel.Get<IClassWithDependancy>();

            Assert.IsInstanceOf<ClassWithDependancy>(classWithDep);
            Assert.AreEqual(classWithDep.WhoAmI(), "ClassWithDependancy of SimpleClass");

            Assert.IsInstanceOf<SimpleClass>(classWithDep.SimpleClass);
            Assert.AreEqual(classWithDep.SimpleClass.WhoAmI(), "SimpleClass");
        }

        /// <summary>
        /// Determines whether this instance can test injection with constructor parameters.
        /// </summary>
        [Test]
        public void CanTestInjectionWithConstructorParameters()
        {
            var classWithConst = this.kernel.Get<IClassWithConstructorParameters>();

            Assert.IsInstanceOf<ClassWithConstructorParameters>(classWithConst);
            Assert.AreEqual(classWithConst.WhoAmI(), "ClassWithConstructorParameters with messageOne:Hello and messageTwo:There");
        }

        /// <summary>
        /// Determines whether this instance can test derrived class injecction.
        /// </summary>
        [Test]
        public void CanTestDerrivedClassInjecction()
        {
            var classWithDep = this.kernel.Get<ClassWithDependancyAlso>();

            Assert.IsInstanceOf<ClassWithDependancyAlso>(classWithDep);
            Assert.AreEqual(classWithDep.WhoAmI(), "ClassWithDependancyAlso of SimpleClassAlso");

            Assert.IsInstanceOf<SimpleClassAlso>(classWithDep.SimpleClass);
            Assert.AreEqual(classWithDep.SimpleClass.WhoAmI(), "SimpleClassAlso");
        }
    }
}