using NUnit.Framework;
using System;
using Advanced.Attributes;
using System.Linq;

namespace Advanced.Attributes
{
	[TestFixture ()]
	public class AttributesExampleTests
	{
		[Test ()]
		public void TestAttributes ()
		{
			var foo = new AnnotatedClass ();
			var attributes = foo.GetType ().GetCustomAttributes (true);

			Assert.IsNotEmpty (attributes.Where (x => x.GetType ().Name == "ImplodeAttribute").ToList());
		}
	}
}