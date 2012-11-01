using System;

namespace NinjectExample.Interfaces
{
	public interface IClassWithDependancy
	{
		string WhoAmI();
		ISimpleClass SimpleClass { get; }
	}
}

