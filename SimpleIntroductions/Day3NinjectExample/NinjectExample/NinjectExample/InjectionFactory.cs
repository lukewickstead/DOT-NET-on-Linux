//-----------------------------------------------------------------------
// <copyright file="InjectionFactory.cs" >Copyright (c) ThereBNone </copyright>
// <author>Luke Wickstead</author>
namespace NinjectExample
{
    using System;
    using Ninject;
    using NinjectExample.Interfaces;
    using NinjectExample.Models;

    /// <summary>
    /// Injection factory.
    /// </summary>
    public sealed class InjectionFactory
    {
        /// <summary>
        /// The injection factory instance.
        /// </summary>
        private static volatile InjectionFactory injectionFactoryInstance;

        /// <summary>
        /// The sync root.
        /// </summary>
        private static object syncRoot = new object();

        /// <summary>
        /// The kernel instance.
        /// </summary>
        private IKernel kernelInstance;

        /// <summary>
        /// Prevents a default instance of the <see cref="NinjectExample.InjectionFactory"/> class from being created.
        /// </summary>
        private InjectionFactory()
        {
            this.kernelInstance = new StandardKernel();
            this.AddBindings();
        }       

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static InjectionFactory Instance
        {
            get
            {
                if (injectionFactoryInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (injectionFactoryInstance == null)
                        {
                            injectionFactoryInstance = new InjectionFactory();
                        }
                    }
                }

                return injectionFactoryInstance;
            }
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel
        {
            get { return this.kernelInstance; }
        }

        /// <summary>
        /// Adds the bindings.
        /// </summary>
        private void AddBindings()
        {
            this.Kernel.Bind<ISimpleClass>().To(typeof(SimpleClass));

            this.Kernel.Bind<IClassWithDependancy>().To(typeof(ClassWithDependancy));

            this.Kernel.Bind<IClassWithConstructorParameters>().To(typeof(ClassWithConstructorParameters)).WithConstructorArgument("messageOne", "Hello").WithConstructorArgument("messageTwo", "There");

            this.Kernel.Bind<ISimpleClass>().To<SimpleClassAlso>().WhenInjectedInto<ClassWithDependancyAlso>();
        }
    }
}