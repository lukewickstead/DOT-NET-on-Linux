using System;
using Ninject;
using Ninject.Planning.Bindings;

namespace TestingMoqingDebugging.NInject
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class WhenClassHas : Attribute
	{
	}
}

