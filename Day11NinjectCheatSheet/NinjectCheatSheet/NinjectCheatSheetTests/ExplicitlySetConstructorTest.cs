using System;
using Ninject;
using NUnit.Framework;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	/// <summary>
	/// Any constructor marked with [Inject] attribute is used prior to any other constructor ordering
	/// </summary>
	[TestFixture()]
	public class ExplicitlySetConstructorTest
	{
		[Test()]
		public void CanSelectCorrectConstructor ()
		{
			IKernel aKernel = new StandardKernel(new MultipleConstructorModule());

			var aClass = aKernel.Get<ExplicitlySetConstructorExample>();

			Assert.That(aClass, Is.InstanceOf<ExplicitlySetConstructorExample>());
			Assert.That(aClass.CalledBy, Is.EqualTo(CalledBy.Empty)); 
		}
	}
}

