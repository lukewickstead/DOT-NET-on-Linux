using System;
using NinjectExample.Interfaces;

namespace NinjectExample.Models
{
	public class ClassWithDependancyAlso
	{
		public ISimpleClass SimpleClass { get; private set; }

		public ClassWithDependancyAlso (ISimpleClass simpleClass)
		{

			this.SimpleClass = simpleClass;
		}


		public string WhoAmI()
		{
			return string.Format("ClassWithDependancyAlso of {0}", SimpleClass.WhoAmI());
		}
	}
}

