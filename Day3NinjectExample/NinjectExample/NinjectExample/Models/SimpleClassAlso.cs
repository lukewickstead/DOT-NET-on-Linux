using System;
using NinjectExample.Interfaces;

namespace NinjectExample.Models
{
	public class SimpleClassAlso : ISimpleClass
	{
		public string WhoAmI()
		{
			return "SimpleClassAlso";
		}	
	}
}

