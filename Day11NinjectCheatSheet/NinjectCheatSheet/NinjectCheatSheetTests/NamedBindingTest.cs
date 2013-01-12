using System;
using NUnit.Framework;
using Ninject;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
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

			Assert.That( classC, Is.InstanceOf<IClass>());
			Assert.That( classC, Is.InstanceOf<KnownC>());
			Assert.That( classD, Is.InstanceOf<IClass>());
			Assert.That( classD, Is.InstanceOf<KnownD>());		
		}
	}
}

