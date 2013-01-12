using System;
using Ninject;

namespace NinjectCheatSheet
{
	public class UserDefinedConstructorExample
	{
		public CalledBy CalledBy { get; set; }

		public UserDefinedConstructorExample ()
		{
			CalledBy = NinjectCheatSheet.CalledBy.Empty;
		}

		public UserDefinedConstructorExample (UnknownA a)
		{
			CalledBy = NinjectCheatSheet.CalledBy.OneUnknown;
		}

		public UserDefinedConstructorExample (KnownC c)
		{
			CalledBy = NinjectCheatSheet.CalledBy.OneKnown;
		}

		public UserDefinedConstructorExample (UnknownA a, KnownC c)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersOneUnknown;
		}

		[Inject]		
		public UserDefinedConstructorExample (UnknownA a, UnknownB b)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersTwoUnknown;
		}

		public UserDefinedConstructorExample (KnownC c, KnownD d)
		{
			CalledBy = NinjectCheatSheet.CalledBy.TwoParametersNoneUnknown;
		}
	}
}

