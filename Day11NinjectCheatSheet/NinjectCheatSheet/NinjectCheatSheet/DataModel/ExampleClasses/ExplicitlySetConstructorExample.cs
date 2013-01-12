using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class ExplicitlySetConstructorExample
	{
		public CalledBy CalledBy { get; set; }

		[Inject]
		public ExplicitlySetConstructorExample ()
		{
			CalledBy = NinjectCheatSheet.CalledBy.Empty;
		}

		public ExplicitlySetConstructorExample (UnknownA a)
		{
			CalledBy = NinjectCheatSheet.CalledBy.OneUnknown;
		}

		public ExplicitlySetConstructorExample (KnownC c)
		{
			CalledBy = NinjectCheatSheet.CalledBy.OneKnown;
		}

		public ExplicitlySetConstructorExample (UnknownA a, KnownC c)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersOneUnknown;
		}

		public ExplicitlySetConstructorExample (UnknownA a, UnknownB b)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersTwoUnknown;
		}

		public ExplicitlySetConstructorExample (KnownC c, KnownD d)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersNoneUnknown;
		}
	}
}

