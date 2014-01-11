using System;
using Ninject;

namespace TestingMoqingDebugging.NInject
{
	public class ExplicitlySetConstructorExample
	{
		public CalledBy CalledBy { get; set; }

		[Inject]
		public ExplicitlySetConstructorExample ()
		{
			CalledBy = CalledBy.Empty;
		}

		public ExplicitlySetConstructorExample (UnknownA a)
		{
			CalledBy = CalledBy.OneUnknown;
		}

		public ExplicitlySetConstructorExample (KnownC c)
		{
			CalledBy = CalledBy.OneKnown;
		}

		public ExplicitlySetConstructorExample (UnknownA a, KnownC c)
		{
			CalledBy = CalledBy.TwoParametersOneUnknown;
		}

		public ExplicitlySetConstructorExample (UnknownA a, UnknownB b)
		{
			CalledBy = CalledBy.TwoParametersTwoUnknown;
		}

		public ExplicitlySetConstructorExample (KnownC c, KnownD d)
		{
			CalledBy = CalledBy.TwoParametersNoneUnknown;
		}
	}
}