using System;

namespace TestingMoqingDebugging.NInject
{
	public class MultipleConstructorExample
	{
		public CalledBy CalledBy { get; set; }

		public MultipleConstructorExample ()
		{
			CalledBy = CalledBy.Empty;
		}

		public MultipleConstructorExample (UnknownA a)
		{
			CalledBy = CalledBy.OneUnknown;
		}

		public MultipleConstructorExample (KnownC c)
		{
			CalledBy = CalledBy.OneKnown;
		}

		public MultipleConstructorExample (UnknownA a, KnownC c)
		{
			CalledBy = CalledBy.TwoParametersOneUnknown;
		}

		public MultipleConstructorExample (UnknownA a, UnknownB b)
		{
			CalledBy = CalledBy.TwoParametersTwoUnknown;
		}

		public MultipleConstructorExample (KnownC c, KnownD d)
		{
			CalledBy = CalledBy.TwoParametersNoneUnknown;
		}
	}
}