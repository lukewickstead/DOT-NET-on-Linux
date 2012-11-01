using System;
using NinjectExample.Interfaces;

namespace NinjectExample.Models
{
	public class ClassWithConstructorParameters : IClassWithConstructorParameters
	{
		public string messageOne { get; private set; }
		public string messageTwo { get; private set; }

		public ClassWithConstructorParameters (string messageOne, string messageTwo)
		{
			this.messageOne = messageOne;
			this.messageTwo = messageTwo;
		}

		public string WhoAmI ()
		{
			return string.Format("ClassWithConstructorParameters with messageOne:{0} and messageTwo:{1}", messageOne, messageTwo);
		}
	}
}

