using System;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings;

namespace TestingMoqingDebugging.NInject
{
	public class WithMetadataModule : NinjectModule
	{
		public override void Load ()
		{
			Bind<IClass> ().To<KnownE> ();
			Bind<IClass> ().To<KnownC> ().WithMetadata ("IsSomething", true);
			Bind<IClass> ().To<KnownD> ().WithMetadata ("IsSomething", false);
		}
	}
}