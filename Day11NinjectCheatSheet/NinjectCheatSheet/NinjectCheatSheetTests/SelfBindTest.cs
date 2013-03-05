using System;
using Ninject;
using NUnit.Framework;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	/// <summary>
	/// Self bind test: classes can be explicitly bound to themselves
	/// </summary>
	[TestFixture()]
	public class SelfBindTest
	{
		[Test()]
		public void CanSelfBind ()
		{
			IKernel aKernel = new StandardKernel();

			aKernel.Bind<SelfBindExample>().To<SelfBindExample>();
			
			var aClass = aKernel.Get<SelfBindExample>();

			Assert.That(aClass, Is.InstanceOf<SelfBindExample>());			 
		}
	}
}

