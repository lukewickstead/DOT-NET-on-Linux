using System;

namespace TestingMoqingDebugging.Debugging
{
	public class WarningAndErrorDirectives
	{
		public WarningAndErrorDirectives ()
		{
			// #warning This code is obsolete (uncomment to show)
			#if DEBUG
			// #error Debug build is not allowed (uncomment to show)
			#endif
		}
	}
}