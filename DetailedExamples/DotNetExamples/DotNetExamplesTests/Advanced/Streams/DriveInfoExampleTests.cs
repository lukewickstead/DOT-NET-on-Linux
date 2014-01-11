using System.IO;
using NUnit.Framework;

namespace Advanced.Streams.Tests
{
	[TestFixture()]
	public class DriveInfoExampleTests
	{
		[Test()]
		public void TestDriveInfo ()
		{
			DriveInfo[]  drives = DriveInfo.GetDrives();

			Assert.IsNotEmpty (drives);
			Assert.IsNotEmpty (drives[0].Name);
			Assert.IsNotEmpty (drives[0].DriveType.ToString());
			Assert.IsNotEmpty (drives[0].IsReady.ToString());
			Assert.IsNotEmpty (drives[0].TotalFreeSpace.ToString());
			Assert.IsNotEmpty (drives[0].DriveFormat);
			Assert.IsNotEmpty (drives[0].VolumeLabel);
		}
	}
}