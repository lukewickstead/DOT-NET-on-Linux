using System;

namespace TheConsole
{
	public class HelloFriend
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello: {0}", Environment.UserName);
			Console.WriteLine ("Would you like to list some information about your computer? (y/n)");

			string inputString = Console.ReadLine ();

			if (inputString.Equals ("y", StringComparison.InvariantCultureIgnoreCase)) {
				DisplayInfo ();
			}	
		}

		private static void DisplayInfo ()
		{
			Console.WriteLine ("OS: {0}", Environment.OSVersion);

			Console.WriteLine ("Drives:");		

			foreach (var drive in Environment.GetLogicalDrives()) {
				Console.WriteLine (drive);
			}	
		}
	}
}
