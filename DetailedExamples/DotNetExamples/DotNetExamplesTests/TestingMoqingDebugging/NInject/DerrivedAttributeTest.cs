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
	public class DerrivedAtrributeTest
	{
		public void CanRsovleWhenClassHasTest ()
		{
			IKernel aKernel = new StandardKernel (new DerrivedAtrributeModule ());

			var aClass = aKernel.Get<InjectWhenClassHas> ();

			Assert.IsInstanceOfType (typeof(InjectWhenMemberAndTargetHas), aClass);
			Assert.IsInstanceOfType (typeof(IClass), aClass.WhenClassHas);
			Assert.IsInstanceOfType (typeof(KnownC), aClass.WhenClassHas);
		}

		public void CanResolveWhenTargetHasTest ()
		{
			IKernel aKernel = new StandardKernel (new DerrivedAtrributeModule ());

			var aClass = aKernel.Get<InjectWhenMemberAndTargetHas> ();

			Assert.IsInstanceOfType ( typeof(InjectWhenMemberAndTargetHas), aClass);		
			Assert.IsInstanceOfType ( typeof(IClass), aClass.WhenTargetHas);		
			Assert.IsInstanceOfType ( typeof(KnownD), aClass.WhenTargetHas);
		}

		[Test()]
		public void CanResolveWhenMemberHasTest ()
		{
			IKernel aKernel = new StandardKernel (new DerrivedAtrributeModule ());

			var aClass = aKernel.Get<InjectWhenMemberAndTargetHas> ();

			Assert.IsInstanceOfType (typeof(InjectWhenMemberAndTargetHas), aClass);
			Assert.IsInstanceOfType (typeof(IClass), aClass.WhenMemberHas);
			Assert.IsInstanceOfType (typeof(KnownE), aClass.WhenMemberHas);
		}	
	}
}

