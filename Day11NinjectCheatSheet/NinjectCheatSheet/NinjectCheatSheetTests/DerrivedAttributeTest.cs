using System;
using Ninject;
using NUnit.Framework;
using NinjectCheatSheet;

namespace NinjectCheatSheetTests
{
	/// <summary>
	/// Auto self bind test: shows that classes are self bound implicitly
	/// </summary>
	[TestFixture()]
	public class DerrivedAtrributeTest
	{
		public void CanRsovleWhenClassHasTest ()
		{
			IKernel aKernel = new StandardKernel (new DerrivedAtrributeModule ());

			var aClass = aKernel.Get<InjectWhenClassHas> ();

			Assert.That (aClass, Is.InstanceOf<InjectWhenMemberAndTargetHas> ());
			Assert.That (aClass.WhenClassHas, Is.InstanceOf<IClass> ());		
			Assert.That (aClass.WhenClassHas, Is.InstanceOf<KnownC> ());		
		}

		public void CanResolveWhenTargetHasTest ()
		{
			IKernel aKernel = new StandardKernel (new DerrivedAtrributeModule ());

			var aClass = aKernel.Get<InjectWhenMemberAndTargetHas> ();

			Assert.That (aClass, Is.InstanceOf<InjectWhenMemberAndTargetHas> ());		
			Assert.That (aClass.WhenTargetHas, Is.InstanceOf<IClass> ());
			Assert.That (aClass.WhenTargetHas, Is.InstanceOf<KnownD> ());	
		}

		[Test()]
		public void CanResolveWhenMemberHasTest ()
		{
			IKernel aKernel = new StandardKernel (new DerrivedAtrributeModule ());

			var aClass = aKernel.Get<InjectWhenMemberAndTargetHas> ();

			Assert.That (aClass, Is.InstanceOf<InjectWhenMemberAndTargetHas> ());		
			Assert.That (aClass.WhenMemberHas, Is.InstanceOf<IClass> ());
			Assert.That (aClass.WhenMemberHas, Is.InstanceOf<KnownE> ());
		}	
	}
}

