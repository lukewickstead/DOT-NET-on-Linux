using System;
using NUnit.Framework;
using Ninject;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
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

			Assert.IsInstanceOfType (typeof(InjectA), childA.Inject);
			Assert.IsInstanceOfType (typeof(InjectB), childB.Inject);
		}
	}
}