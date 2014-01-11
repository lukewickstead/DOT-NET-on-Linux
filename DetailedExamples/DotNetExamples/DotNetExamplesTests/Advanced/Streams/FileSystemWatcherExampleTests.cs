using NUnit.Framework;
using System;
using Advanced.Streams;
using System.Threading;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class FileSystemWatcherExampleTests
	{
		[Test ()]
		public void TestCase ()
		{
			var watcher = new FileSystemWatcherExample ();

			var aFileName = watcher.AddFile ();
			Thread.Sleep (10);

			watcher.AddFile ();
			Thread.Sleep (10);

			watcher.AddFile ();
			Thread.Sleep (10);

			watcher.RenameFile (aFileName);
			Thread.Sleep (10);


			Assert.AreEqual (3, watcher.OnChangedCount);
			Assert.AreEqual (1, watcher.OnRenamedCount);
		}
	}
}