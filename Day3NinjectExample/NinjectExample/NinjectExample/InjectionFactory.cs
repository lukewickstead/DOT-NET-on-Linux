using System;
using Ninject;
using NinjectExample.Interfaces;
using NinjectExample.Models;

public sealed class InjectionFactory
{
	private static volatile InjectionFactory injectionFactoryInstance;
	private static object syncRoot = new Object ();
	IKernel kernelInstance;

	public IKernel kernel {
		get { return kernelInstance; }
	}

	private InjectionFactory ()
	{
		kernelInstance = new StandardKernel ();
		AddBindings ();
	}

	public static InjectionFactory Instance {

		get {
			if (injectionFactoryInstance == null) {
				lock (syncRoot) {
					if (injectionFactoryInstance == null) 
						injectionFactoryInstance = new InjectionFactory ();
				}
			}

			return injectionFactoryInstance;
		}
	}

	private void AddBindings ()
	{

		kernel.Bind<ISimpleClass> ().To (typeof(SimpleClass));

		kernel.Bind<IClassWithDependancy> ().To (typeof(ClassWithDependancy));

		kernel.Bind<IClassWithConstructorParameters> ().To (typeof(ClassWithConstructorParameters)).
			WithConstructorArgument ("messageOne", "Hello").
			WithConstructorArgument ("messageTwo", "There");

		kernel.Bind<ISimpleClass>().To<SimpleClassAlso>().WhenInjectedInto<ClassWithDependancyAlso>();
	}
}