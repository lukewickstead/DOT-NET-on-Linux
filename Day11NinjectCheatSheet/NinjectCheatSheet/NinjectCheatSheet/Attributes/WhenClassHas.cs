using System;
using Ninject;
using Ninject.Planning.Bindings;

namespace NinjectCheatSheet
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class WhenClassHas : Attribute
	{
	}
}

