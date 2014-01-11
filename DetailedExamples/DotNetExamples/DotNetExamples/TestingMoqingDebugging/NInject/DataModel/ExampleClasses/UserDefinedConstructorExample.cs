using System;
using Ninject;

namespace TestingMoqingDebugging.NInject
{
	public class UserDefinedConstructorExample
	{
		public CalledBy CalledBy { get; set; }

		public UserDefinedConstructorExample ()
		{
			CalledBy = CalledBy.Empty;
		}

		public UserDefinedConstructorExample (UnknownA a)
		{
			CalledBy = CalledBy.OneUnknown;
		}

		public UserDefinedConstructorExample (KnownC c)
		{
			CalledBy = CalledBy.OneKnown;
		}

		public UserDefinedConstructorExample (UnknownA a, KnownC c)
		{
			CalledBy = CalledBy.TwoParametersOneUnknown;
		}

		[Inject]		
		public UserDefinedConstructorExample (UnknownA a, UnknownB b)
		{
			CalledBy = CalledBy.TwoParametersTwoUnknown;
		}

		public UserDefinedConstructorExample (KnownC c, KnownD d)
		{
			CalledBy = CalledBy.TwoParametersNoneUnknown;
		}
	}
}