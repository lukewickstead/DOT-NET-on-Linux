using System;

namespace TestingMoqingDebugging.Debugging
{
	public class PragmaExample
	{
		public PragmaExample ()
		{
			#pragma warning disable 
			while (false) {     
				// Compiler Warning: unreachable code. 
			} 

			int i;  // Compiler Warning: i is declared but never used
			#pragma warning restore
		}
	}
}