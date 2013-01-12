using System;

namespace NinjectCheatSheet
{
	public class MultipleConstructorExample
	{
		public CalledBy CalledBy { get; set; }

		public MultipleConstructorExample ()
		{
			CalledBy = NinjectCheatSheet.CalledBy.Empty;
		}

		public MultipleConstructorExample (UnknownA a)
		{
			CalledBy = NinjectCheatSheet.CalledBy.OneUnknown;
		}

		public MultipleConstructorExample (KnownC c)
		{
			CalledBy = NinjectCheatSheet.CalledBy.OneKnown;
		}

		public MultipleConstructorExample (UnknownA a, KnownC c)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersOneUnknown;
		}

		public MultipleConstructorExample (UnknownA a, UnknownB b)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersTwoUnknown;
		}

		public MultipleConstructorExample (KnownC c, KnownD d)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersNoneUnknown;
		}
	}
}

