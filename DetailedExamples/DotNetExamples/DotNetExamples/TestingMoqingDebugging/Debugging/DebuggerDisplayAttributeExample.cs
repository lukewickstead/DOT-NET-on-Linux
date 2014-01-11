using System;
using System.Diagnostics;

namespace TestingMoqingDebugging.Debugging
{
	[DebuggerDisplay("Name = {FirstName} {LastName}")] 
	public class DebuggerDisplayAttributeExample 
	{     
		public string FirstName { get; set; }     
		public string LastName { get; set; } 
	}
}