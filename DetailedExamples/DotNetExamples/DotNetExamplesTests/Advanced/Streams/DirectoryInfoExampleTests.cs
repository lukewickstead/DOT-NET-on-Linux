using System;
using System.IO;
using NUnit.Framework;

namespace Advanced.Streams.Tests
{
	[TestFixture()]
	public class DirectoryInfoExampleTests
	{
		[Test ()]
		public void TestCreate ()
		{
			var tempDir = Path.GetTempPath ();
			var pathName = Path.Combine (tempDir, "Foo");

			var dir = new DirectoryInfo (pathName); 
			dir.Create ();
			Assert.IsTrue (Directory.Exists (dir.FullName));

			dir.Delete ();
			Assert.IsFalse (Directory.Exists (dir.FullName));
		}

		[Test ()]
		public void TestProperties ()
		{
			var tempDirPath = Path.GetTempPath ();
			var tempDir = new DirectoryInfo (tempDirPath); 

			tempDir.CreateSubdirectory ("Foo");
			var fooTempDir = new DirectoryInfo (Path.Combine (tempDirPath, "Foo")); 

			Assert.IsTrue (fooTempDir.FullName.Contains (tempDir.FullName));
			Assert.AreEqual ("Foo", fooTempDir.Name);
			Assert.AreEqual (tempDir.Name, fooTempDir.Parent.Name);
			Assert.AreEqual (tempDir.Root.FullName, fooTempDir.Root.FullName);
		}

		[Test()]
		public void TestGetFiles ()
		{
			var dir = new DirectoryInfo (Path.GetTempPath ());
			FileInfo[] fileinfos = dir.GetFiles ("*.*", SearchOption.AllDirectories);   
			Assert.IsNotEmpty (fileinfos);
		}
	}
}