using System;
using System.Diagnostics;

namespace MultiThreading.ProcessAppDomains
{
	public class ProcessExample
	{
		public static Process[] GetRunningProcesses (string name, string serverNameOrIP)
		{
			if (!string.IsNullOrEmpty (name) && !string.IsNullOrEmpty (serverNameOrIP)) {
				return Process.GetProcessesByName (name, serverNameOrIP); 
			} else if (!string.IsNullOrEmpty (name)) {
				return Process.GetProcessesByName (name);
			} 

			return Process.GetProcesses ();
		}

		public static string GetNameOfProcessWithId (int id)
		{
			Process aProcess = Process.GetProcessById (id);

			if (aProcess == null) {
				return string.Empty;
			}

			return aProcess.ProcessName;
		}

		public static void KillProcessWithId (int id)
		{
			Process aProcess = Process.GetProcessById (id);

			if (aProcess != null) {
				aProcess.Kill ();
			}
		}

		public static void StartApp (string appName, string aParam)
		{
			if (string.IsNullOrEmpty (aParam)) {
				Process.Start (appName);

			} else {
				Process.Start (appName, aParam);
			}
		}

		public static void StartAppWithEnvironmentParams (string appName, string aParam)
		{
			if (string.IsNullOrEmpty (aParam)) {
				Process.Start (new ProcessStartInfo (appName) { 
					CreateNoWindow = true, 
					WorkingDirectory = @"c:\" 
				});

			} else {
				Process.Start (new ProcessStartInfo (appName, aParam) { 
					CreateNoWindow = true, 
					WorkingDirectory = @"c:\" 
				});
			}
		}
	}
}