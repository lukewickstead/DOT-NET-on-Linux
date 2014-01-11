using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Advanced.AdvancedFeatures.Tests
{
	[TestFixture()]
	public class RegularExspressionTests
	{
		[Test()]
		public void TestIsMatch ()
		{
			var isMatch = Regex.IsMatch ("ABC123", @"[A-Z]{3}[0-9]{3}", RegexOptions.IgnoreCase);

			Assert.IsTrue (isMatch);        
		}
	
		[Test()]
		public void TestMatch ()
		{
			Match m = Regex.Match ("A1B2C3", @"\b[A-Z][0-9]", RegexOptions.IgnoreCase);

			if (m.Success)
				Console.WriteLine ("Found '{0}' at position {1}.", m.Value, m.Index);

			Assert.IsTrue (m.Success);
			Assert.AreEqual (1, m.Groups.Count);
			Assert.AreEqual ("A1", m.Value);
			Assert.AreEqual (0, m.Index);
		}
		
		[Test()]
		public void TestMatches ()
		{
			MatchCollection m = Regex.Matches ("A1 B2 C3", @"\b[A-Z][0-9]", RegexOptions.Compiled);

			Assert.AreEqual(3, m.Count);

			Assert.AreEqual(0, m[0].Index);
			Assert.AreEqual("A1", m[0].Value);


			Assert.AreEqual(3, m[1].Index);
			Assert.AreEqual("B2", m[1].Value);

			Assert.AreEqual(6, m[2].Index);
			Assert.AreEqual("C3", m[2].Value);
		}

		[Test()]
		public void TestReplace ()
		{
			var newString = Regex.Replace ("A,B,C", @"[,]", "-", RegexOptions.IgnoreCase);
		
			Assert.AreEqual ("A-B-C", newString);		
		}

		[Test()]
		public void TestSplit ()
		{
			string[] results = Regex.Split ("A,B,C", @"[,]", RegexOptions.IgnoreCase);

			Assert.AreEqual (3, results.Length);
			Assert.AreEqual ("A", results [0]);
			Assert.AreEqual ("B", results [1]);
			Assert.AreEqual ("C", results [2]);
		}

		[Test()]
		public void TestSurname ()
		{
			Regex rx = new Regex(@"^[A-Z][A-Za-z’-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

			Assert.IsTrue(rx.IsMatch("Wickstead"));
			Assert.IsTrue(rx.IsMatch("Mcghee"));
			Assert.IsTrue(rx.IsMatch("ElMcGonzo"));
		}

		[Test()]
		public void TestPostCode ()
		{
			Regex rx = new Regex(@"^[A-Z]{2}[0-9]\s?[0-9]{1,2}[A-Z]{2}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

			Assert.IsTrue(rx.IsMatch("PL7 4EG"));
			Assert.IsTrue(rx.IsMatch("BS14PS"));
			Assert.IsTrue(rx.IsMatch("BS1 44PS"));
		}
	}
}