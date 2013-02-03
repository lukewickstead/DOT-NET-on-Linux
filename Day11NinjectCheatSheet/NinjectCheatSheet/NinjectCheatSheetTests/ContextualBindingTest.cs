using System;
using NUnit.Framework;
using Ninject;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class ContextualBindingTest
	{
		[Test()]
		public void TestCaseTwo ()
		{

			var kernel = new StandardKernel (new ContextualBindingModule ());		

			var childA = kernel.Get<ChildA> ();
			var childB = kernel.Get<ChildB> ();

			Assert.That (childA.Inject, Is.InstanceOf<InjectA> ());
			Assert.That (childB.Inject, Is.InstanceOf<InjectB> ());
		}
	}
}

