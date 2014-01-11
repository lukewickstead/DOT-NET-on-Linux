using NUnit.Framework;
using System.IO;

namespace Advanced.Streams.Tests
{
	[TestFixture ()]
	public class DirectoryExampleTests
	{
		[Test ()]
		public void TestGetLogiclDrives ()
		{
			foreach (var aDir in Directory.GetLogicalDrives ()) {
				Assert.IsTrue (Directory.Exists (aDir));
			}
		}

		[Test()]
		public void TestDelete()
		{
			var aDir = Path.GetTempPath();
			var bDir = Path.Combine (aDir, "Second");
			var cDir = Path.Combine (aDir, "Third");
			var dDir = Path.Combine (aDir, "Fourth");

			Directory.CreateDirectory (bDir);
			Directory.CreateDirectory (cDir);
			Directory.CreateDirectory (dDir);

			Directory.Delete (cDir);
			Directory.Delete (bDir, true);
		}
	}
}