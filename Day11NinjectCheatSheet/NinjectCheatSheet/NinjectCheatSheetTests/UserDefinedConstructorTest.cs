using System;
using Ninject;
using NUnit.Framework;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	/// <summary>
	/// User defined constructor test: Marking a constructor with the Inject parameter explicitly sets the constructor to be used.
	/// </summary>
	[TestFixture()]
	public class UserDefinedConstructorTest
	{
		[Test()]
		public void CanSelectUserDefinedConstructor ()
		{
			IKernel aKernel = new StandardKernel(new MultipleConstructorModule());

			var aClass = aKernel.Get<UserDefinedConstructorExample>();

			Assert.That(aClass, Is.InstanceOf<UserDefinedConstructorExample>());			 
			Assert.That (aClass.CalledBy, Is.EqualTo(CalledBy.TwoParametersTwoUnknown)); 
		}
	}
}

