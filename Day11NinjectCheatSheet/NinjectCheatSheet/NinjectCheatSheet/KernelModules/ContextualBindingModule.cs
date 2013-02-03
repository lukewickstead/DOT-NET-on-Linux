using System;
using Ninject.Modules;

namespace NinjectCheatSheet
{

	public class ContextualBindingModule  : NinjectModule
	{
		public override void Load ()
		{
			Bind<ChildA> ().ToSelf ();
			Bind<ChildB> ().ToSelf ();

			Bind<IInject> ().To<InjectA> ().WhenInjectedInto (typeof(GrandParent));
			Bind<IInject> ().To<InjectB> ().WhenInjectedExactlyInto (typeof(ChildB));	
		}
	}
}

