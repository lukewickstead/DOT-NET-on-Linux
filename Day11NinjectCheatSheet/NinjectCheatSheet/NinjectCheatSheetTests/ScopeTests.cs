using System;
using Ninject;
using NinjectCheatSheet;
using NUnit.Framework;

namespace NinjectCheatSheetTests
{
	/// <summary>
	/// Scope tests define when a new instance is created.
	/// Can be one of; InTransientScope(), InSingletonScope(), InThreadScope(), InRequestScope(), InScope(Func<object>)
	/// </summary>
	[TestFixture()]
	public class ScopeTests
	{
		/// <summary>
		/// InTransientScope; always creates a new instance when got. 
		/// </summary>
		[Test()]
		public void InTransientScopeTest ()
		{
			IKernel aKernel = new StandardKernel (new ScopeModule ());

			var firstC = aKernel.Get<KnownC> ();
			var secondC = aKernel.Get<KnownC> ();

			Assert.That (firstC, Is.InstanceOf<KnownC> ());
			Assert.That (secondC, Is.InstanceOf<KnownC> ());
			Assert.That (firstC, Is.SameAs (secondC));
		}

		/// <summary>
		/// InSingletonScope: only every one instance.
		/// </summary>
		[Test()]
		public void InSingletonScopeTest ()
		{
			IKernel aKernel = new StandardKernel (new ScopeModule ());

			var firstD = aKernel.Get<KnownD> ();
			var secondD = aKernel.Get<KnownD> ();

			Assert.That (firstD, Is.InstanceOf<KnownD> ());
			Assert.That (secondD, Is.InstanceOf<KnownD> ());
			Assert.That (firstD, Is.Not.SameAs (secondD));
		}
	}
}

