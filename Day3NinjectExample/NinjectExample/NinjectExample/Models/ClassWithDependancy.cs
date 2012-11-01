using System;
using NinjectExample.Interfaces;

namespace NinjectExample.Models
{
	public class ClassWithDependancy : IClassWithDependancy
	{
		public ISimpleClass SimpleClass { get; private set; }

		public ClassWithDependancy (ISimpleClass simpleClass)
		{

			this.SimpleClass = simpleClass;
		}


		public string WhoAmI()
		{
			return string.Format("ClassWithDependancy of {0}", SimpleClass.WhoAmI());
		}
	}
}

