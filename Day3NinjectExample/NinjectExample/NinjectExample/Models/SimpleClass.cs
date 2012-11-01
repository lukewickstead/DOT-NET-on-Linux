using System;
using NinjectExample.Interfaces;

namespace NinjectExample.Models
{
	public class SimpleClass : ISimpleClass
	{
		public string WhoAmI()
		{
			return "SimpleClass";
		}	
	}
}

