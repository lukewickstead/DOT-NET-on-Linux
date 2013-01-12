using System;
using NUnit.Framework;
using Ninject;

using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	[TestFixture()]
	public class WithMetadataTest
	{
		[Test()]
		public void CanInjectWithMetaDataTest ()
		{
			var kernel = new StandardKernel( new WithMetadataModule());

			var isSome =  kernel.Get<InjectWithIsSomething>();
			var isNotSome =  kernel.Get<InjectWithIsNotSomething>();
		
			Assert.That( isSome.InjectedClass, Is.InstanceOf<IClass>());
			Assert.That( isSome.InjectedClass, Is.InstanceOf<KnownC>());

			Assert.That( isNotSome.InjectedClass, Is.InstanceOf<IClass>());
			Assert.That( isNotSome.InjectedClass, Is.InstanceOf<KnownD>());
		}
	}
}

