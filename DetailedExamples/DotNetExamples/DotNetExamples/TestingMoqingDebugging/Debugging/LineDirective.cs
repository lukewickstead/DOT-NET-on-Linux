using System;

namespace TestingMoqingDebugging.Debugging
{
	public class LineDirective
	{
		public static int Example ()
		{
			#line 200 "OtherFileName"     

			int a = 1;    	// line 200 

			#line default     

			int b = 2;   	// line 4 
		
			#line hidden 

			int c = 3; 		// hidden     
			int d = 4; 		// line 
	
			return a + b + c + d;
		}
	}
}