using System;
using Ninject;

namespace TestingMoqingDebugging.NInject
{
	public class InjectWithIsNotSomething
	{
		public IClass InjectedClass{ get; set; }

		public InjectWithIsNotSomething([IsNotSomething] IClass aClass)
		{
			InjectedClass = aClass;
		}
	}	
}
