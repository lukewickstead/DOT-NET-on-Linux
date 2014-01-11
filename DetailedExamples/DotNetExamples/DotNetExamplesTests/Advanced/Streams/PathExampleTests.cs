using System;
using System.IO;
using NUnit.Framework;

namespace Advanced.Streams.Tests
{
	public class PathExampleTests
	{
		[Test()]
		public void TestCombine ()
		{
			string fullPath = Path.Combine (Path.GetTempPath(), "test.dat"); 

			Assert.AreEqual (String.Format ("{0}{1}", Path.GetTempPath(), "test.dat"), fullPath);
		}
	}
}