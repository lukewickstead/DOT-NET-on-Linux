using System;
using System.IO;

namespace Advanced.Streams
{
	public class FileSystemWatcherExample
	{
		public int OnChangedCount { get; set; }

		public int OnRenamedCount { get; set; }

		private FileSystemWatcher watcher = new FileSystemWatcher ();

		public FileSystemWatcherExample ()
		{
			watcher.Path = Path.GetTempPath ();
			watcher.Filter = "*.txt";  

			watcher.NotifyFilter = NotifyFilters.FileName;

			watcher.Changed += new FileSystemEventHandler (OnChanged);   
			watcher.Created += new FileSystemEventHandler (OnChanged);   
			watcher.Deleted += new FileSystemEventHandler (OnChanged);   
			watcher.Renamed += new RenamedEventHandler (OnRenamed);

			watcher.EnableRaisingEvents = true;
		}

		public string AddFile ()
		{
			var aFileName = Path.GetTempFileName () + ".txt";
			File.WriteAllText (aFileName, "Text");

			return aFileName;
		}

		public void RenameFile (string aFileName)
		{
			File.Move (aFileName, aFileName + "new.txt");
		}

		private void OnChanged (object source, FileSystemEventArgs e)
		{
			OnChangedCount++;
		}

		private void OnRenamed (object source, RenamedEventArgs e)
		{
			OnRenamedCount++;
		}
	}
}