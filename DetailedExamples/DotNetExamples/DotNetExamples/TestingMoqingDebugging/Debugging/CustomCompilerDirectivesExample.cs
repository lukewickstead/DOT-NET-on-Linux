#define TRACE
//#define DEBUG
#undef DEBUG
using System;

namespace TestingMoqingDebugging.Debugging
{
	public class CustomCompilerDirectivesExample
	{
		public bool HitOne { get; private set; }

		public bool HitTwo { get; private set; }

		public bool HitThree { get; private set; }

		public CustomCompilerDirectivesExample ()
		{
			#if TRACE        
			HitOne = true; 
			Console.WriteLine ("Custom symbol is defined");     
			#endif 

			#if (DEBUG)
			HitTwo = false;
			#endif

			#if (TRACE || DEBUG)
			HitThree = true;
			#endif
		}
	}
}