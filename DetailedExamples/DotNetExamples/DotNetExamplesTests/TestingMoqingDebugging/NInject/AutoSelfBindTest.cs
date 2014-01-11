using System;
using Ninject;
using NUnit.Framework;
using TestingMoqingDebugging.NInject;

namespace TestingMoqingDebugging.NInject.Tests
{
	/// <summary>
	/// Auto self bind test: shows that classes are self bound implicitly
	/// </summary>
	[TestFixture()]
	public class AutoSelfBindTest
	{
		[Test()]
		public void CanAutoSelfBind ()
		{
			IKernel aKernel = new StandardKernel();

			var aClass = aKernel.Get<AuoSelfBindExample>();

			Assert.IsInstanceOfType(typeof(AuoSelfBindExample), aClass);			 
		}
	}
}