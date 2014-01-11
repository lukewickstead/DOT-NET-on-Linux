using System;

namespace TestingMoqingDebugging.Debugging
{
	public class CompilerDirectivesExample
	{
		public bool? HitOne { get; private set; }

		public bool? HitTwo { get; private set; }

		public void Run ()
		{
			#if DEBUG 
				HitOne = true;
			#else         
				HitOne = false;
			#endif

			#if DEBUG     
				Log ();     
			#endif 
		}

		private  void Log ()
		{     
			HitTwo = true;
		}
	}
}