using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class MyTests
{
	[Test]
	public void BasicTest ()
	{
		Assert.IsTrue (true);
	}

	[Test]
	public void BasicFailedTest ()
	{
		Assert.IsTrue (false);
	}
}