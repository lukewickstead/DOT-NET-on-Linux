using System;
using NUnit.Framework;
using Ninject;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
{
	/// <summary>
	/// An arbitury name can be used to distinguish multiple classes bound to the same entity
	/// </summary>
	[TestFixture()]
	public class NamedBindingTest
	{
		[Test()]
		public void TestCase ()
		{
			var aKernel = new StandardKernel(new NamedBindingModule());

			var classC = aKernel.Get<IClass>("NameknownC");
			var classD = aKernel.Get<IClass>("NameknownD");

			Assert.IsInstanceOfType( typeof(IClass), classC);
			Assert.IsInstanceOfType( typeof(KnownC), classC);
			Assert.IsInstanceOfType( typeof(IClass), classD);
			Assert.IsInstanceOfType( typeof(KnownD), classD);		
		}
	}
}