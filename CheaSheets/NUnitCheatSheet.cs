using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnitCheatSheet
{
	/// <summary>
	/// TestFixtureSetUp: Provides a config class for setting up and tearing down the test fixture.
	/// Provides the config for all TestFixture classes witin the same namespace.
	/// </summary>
	[SetUpFixture]
  	public class TestFixtureSetUp
  	{
		/// <summary>
		/// SetUp; run once before all tests in a test fixture. 
		/// Run once for each TestFixture in the same namespace.
		/// </summary>
	    [SetUp]
		public void RunBeforeAnyTests()
		{
		  // Set up code here.
		}
		/// <summary>
		/// TearDown; run once after all tests in a test fixture. 
		/// Run once for each TestFixture in the same namespace.
		/// </summary>
	    [TearDown]
		public void RunAfterAnyTests()
		{
		  // Clear up code here.
		}
  	}

	/// <summary>
	/// Factory class for providing test data for tests with the TestCaseSource attribue.
	/// </summary>
	public class TestCaseDataFactory
	{
		/// <summary>
		/// TestCaseSource tests can consume IEnumerable properties which return TestCaseData
		/// </summary>
	  	public static IEnumerable TestCasesDataForTestCaseSourceTest
		{
		    get
		    {
		      yield return new TestCaseData( 1, "1" ).Returns( 2 ); // Defines the test data and the expected return
		      yield return new TestCaseData( 2, "2" ).Returns( 4 );
		      yield return new TestCaseData( 0, "a" )
						.Throws(typeof(ArgumentException)); // Defines the test data and the expected throw exception
		    }
		}  
	}

	/// <summary>
	/// TestFixture defines a class of tests
	/// </summary>
	[TestFixture(), Category("MyTests"), Description("NUnut Cheat Sheet!")]
	public class Test
	{
		/// <summary>
		/// TestCaseSource attributes can use static properties to return an array of test data
		/// </summary>
		public static object[] CaseSourceTestData =
		{
		    new object[] { 1, 1.1m, "2.1" },
			new object[] { 2, 2.2m, "4.2" },
			new object[] { 3, 3.3m, "6.3" },
		};

		# region Setup and Tear Down
		/// <summary>
		/// TestFixtureSetUp called once before any tests have been run in the same TestFixture
		/// </summary>
		[TestFixtureSetUp] public void FixtureSetUp()
    	{ 
			// Set up code here.
		}
		/// <summary>
		/// TestFixtureTearDown called once after all tests have been run in the same TestFixture
		/// </summary>
    	[TestFixtureTearDown] public void FixtureTearDown()
    	{
			// Clear up code here.
		}

		/// <summary>
		/// SetsUp is called once before each Test within the same TestFxiture
		/// </summary>
		[SetUp] public void SetUp()
    	{
			// Set up code here.
			// If this throws an exception no Test in the TestFixture are run.
		}

		/// <summary>
		/// TearsDown is called once after each Test within the same TestFixture.
		/// </summary>
    	[TearDown] public void TearDown()
    	{ 
			 // Clear up code here.
			// Will not run if no tess are run due to [SetUp] throwing an exception
		}
		# endregion

		/// <summary>
		/// ExpectedException defines what exception and how it is configured
		/// </summary>
		[Test, ExpectedException( typeof(Exception), ExpectedMessage = "Foo", MatchType = MessageMatch.Exact)]
		public void ExpectedExceptionAttributeTest() 
		{
			// MessageMatch is an enum of: Contains, Exact, Regex, StartsWith
			throw new Exception("Foo");
		}

		/// <summary>
		/// Explicit defines tests which are only run manualy.
		/// </summary>
		[Test, Explicit("Test has to be run explicitly")]
    	public void ExplicitAttributeTest()
    	{
		}

		/// <summary>
		/// Ignore marks tests which are not run even if run manually
		/// </summary>
		[Test, Ignore("Ignore this test")]
    	public void IgnoreAttribueTest()
    	{
		}

		/// <summary>
		/// MaxTimeAttribute defines the max run time in milliseconds before the test is considered as failed but allowed to complete.
		/// </summary>
		[Test, MaxTimeAttribute(2000)]
		public void MaxtimeAttributeTest()
		{    
		}

		/// <summary>
		/// Timeout defines the max run time in milliseconds before the test is automatically failed. 
		/// Can be used on TestFixture to set for each contained Test's 
		/// </summary>
		[Test, Timeout(200)]
		public void TimeOutTest()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		[Test, Platform("Mono"), Culture("en-GB")]
		public void PlatformAttributeTest()
  		{
			// Can also provide exclusion culture and platform
			// Test case is ignored if Platform or Cultrue can not be provided
 		}

		/// <summary>t
		/// Property: categorises the test witin the test output XML.
		/// </summary>
		[Test, Property("PropertyName", "Value")]
		public void PropertyAttributeTest()
    	{}

		/// <summary>
		/// Custom Property: categorises the test within the test output XML.
		/// </summary>
		[Test, CustomPropertyAttribute(CustomPropertyValue.One)]
		public void CustomPropertyAttributeTest()
    	{}


		#region Parameterized
		/// <summary>
		/// Combinatorial: The test is run with each combination of Values for each parameter 
		/// </summary>

		[Test, Combinatorial]
		public void CombinatorialAttributeTest ([Values(1,2,3)] int a, [Values("a", "b", "c")] string b)
		{
			// Called 9 times with  parameter pairs of: {1,a}, {1,b}, {1,c}, {2,a}, {3,b}....			
		}

		/// <summary>
		/// Random: Test can be run with a random value. Random(Min,Max,Count)
		/// </summary>
		[Test]
		public void RandomAttributeTest(
    	[Random(1, 10, 2)] int value)
		{
			// Called 2 times with a random integer between 1 and 10
			Assert.That(value, Is.InRange(1,10));
		}

		/// <summary>
		/// Sequential: Parameters with values are run in sequence
		/// </summary>
		[Test, Sequential]
		public void SequentialAttributeTest(
    	[Values(1,2,3)] int x,
    	[Values("A","B")] string s)
		{
			// Test runs for parameter pairs {1,A}, {2,B}, {3, null}
		}

		/// <summary>
		/// Range: Parameter is run with a sequence of values incremented. Range(Min,Max,Increment).
		/// </summary>
		[Test]
		public void RangeAttributeTest(
    	[Range(0.0, 1, 0.5)] decimal value)
		{    
			// Test run for parameters, 0.0, 0.5, 1.0
			Assert.That(value, Is.InRange(0m,1m));
		}

		/// <summary>
		/// TestCaseSource: referencing a public property which privides a sequence of test data 
		/// </summary>
		[Test, TestCaseSource("CaseSourceTestData")]  
		public void CaseSourceTest(int a, decimal b, string c)
		{
			// Can also specify the class to which the property is found upon.
			Assert.That(a + b, Is.EqualTo(Decimal.Parse(c)));
		}

		/// <summary>
		/// TestCaseSource: referncing a class and property which provides a sequence of test data and expected output.
		/// </summary>
		[Test,TestCaseSource(typeof(TestCaseDataFactory),"TestCasesDataForTestCaseSourceTest")]
		public decimal TestCaseSourceTest(int a, string b)
		{
			int bInt;
			if( !int.TryParse(b, out bInt))
				throw new ArgumentException(string.Format("Can not parse '{0}' to an integer", b), "b");

			return a + bInt;
		}

		/// <summary>
		/// TestCase: provides a test input data and expected result.
		/// </summary>
		[TestCase(1,1, Result=2)]
		[TestCase(2,2, Result=4)]
		[TestCase(3,3, Result=6)]
		public int TestCaseTest(int a, int b)
		{
		  return( a + b);
		}
		#endregion

		/// <summary>
		/// Assertion Based Test
		/// </summary>
		[Test(), Category("Assertion based testing")]
		public void TestAssertions ()
		{

			// Equality 
			Assert.AreEqual (true, true);
			Assert.AreNotEqual (true, false);

			// Identity	
			Assert.AreSame (string.Empty, string.Empty);
			Assert.AreNotSame (new object (), new object ());
			Assert.Contains (string.Empty, new List<object> (){string.Empty});

			// Condition
			Assert.IsTrue (true);
			Assert.IsFalse (false);
			Assert.IsNull (null);
			Assert.IsNaN (Double.NaN); 
			Assert.IsEmpty (new List<object> ());
			Assert.IsEmpty (new List<object> ());
			Assert.IsNotEmpty (new List<object> (){1});
			Assert.IsNotEmpty ("Foo");

			// Comparision
			Assert.Greater (Decimal.MaxValue, Decimal.MinValue);
			Assert.GreaterOrEqual (Decimal.MinValue, Decimal.MinValue);
			Assert.Less (Decimal.MinValue, Decimal.MaxValue);
			Assert.LessOrEqual (Decimal.MinValue, Decimal.MinValue);

			// Types
			Assert.IsInstanceOf<decimal> (decimal.MinValue);
			Assert.IsNotInstanceOf<int> (decimal.MinValue);
			Assert.IsNotAssignableFrom (typeof(List<Type>), string.Empty);        	// Equivalent to Type.IsAssignableFrom Method 
			Assert.IsAssignableFrom (typeof(List<decimal>), new List<decimal> ()); 	// http://msdn.microsoft.com/en-gb/library/system.type.isassignablefrom.aspx
			Assert.IsNotAssignableFrom<List<Type>> (string.Empty);        			
			Assert.IsAssignableFrom<List<decimal>> (new List<decimal> ()); 			

	
			// Exceptions
			Assert.Throws (typeof(ArgumentNullException), () => { 
				throw new ArgumentNullException (); }
			);

			Assert.Throws<ArgumentNullException> (() => {
				throw new ArgumentNullException (); }
			);

			Assert.DoesNotThrow (() => { });

			Assert.Catch (typeof(Exception), () => {
				throw new ArgumentNullException (); }
			);

			Assert.Catch<Exception> (() => { // Similar as Throws but allows any derrived class of the thrown exception
				throw new ArgumentNullException (); }
			);
		

			// Strings
			StringAssert.Contains ("Foo", "MooFooMoo");
			StringAssert.StartsWith ("Foo", "FooMoo");
			StringAssert.EndsWith ("Moo", "FooMoo"); 
			StringAssert.AreEqualIgnoringCase ("FOO", "foo");
			StringAssert.IsMatch ("[0-9]", "1");


			// Collections
			CollectionAssert.AllItemsAreInstancesOfType (new List<decimal> (){ 0m }, typeof(decimal));
			CollectionAssert.AllItemsAreNotNull (new List<decimal> (){ 0m });
			CollectionAssert.AllItemsAreUnique (new List<decimal> (){ 0m, 1m });
			CollectionAssert.AreEqual (new List<decimal> (){ 0m }, new List<decimal> (){ 0m });
			CollectionAssert.AreEquivalent (new List<decimal> (){ 0m, 1m }, new List<decimal> (){ 1m, 0m }); // Same as AreEqual though order does not mater
			CollectionAssert.AreNotEqual (new List<decimal> (){ 0m }, new List<decimal> (){ 1m });
			CollectionAssert.AreNotEquivalent (new List<decimal> (){ 0m, 1m }, new List<decimal> (){ 1m, 2m });  // Same as AreNotEqual though order does not matter
			CollectionAssert.Contains (new List<decimal> (){ 0m, 1m }, 1m);
			CollectionAssert.DoesNotContain (new List<decimal> (){ 0m, 1m }, 2m);
			CollectionAssert.IsSubsetOf (new List<decimal> (){ 1m }, new List<decimal> (){ 0m, 1m }); // {1} is considered a SubSet of {1,2}
			CollectionAssert.IsNotSubsetOf (new List<decimal> (){ 1m, 2m }, new List<decimal> (){ 0m, 1m }); 
			CollectionAssert.IsEmpty (new List<decimal> (){ }); 
			CollectionAssert.IsNotEmpty (new List<decimal> (){ 1m }); 
			CollectionAssert.IsOrdered (new List<decimal> (){ 1m, 2m, 3m });
			CollectionAssert.IsOrdered (new List<string> (){ "a", "A", "b"}, StringComparer.CurrentCultureIgnoreCase);
			CollectionAssert.IsOrdered (new List<int> (){ 3,2,1}, new ReverseComparer()); // Only supports ICompare and not ICompare<T> as of version 2.6


			//  File Assert: various ways to compare a stream or file.
			FileAssert.AreEqual (new MemoryStream (), new MemoryStream ());
			FileAssert.AreEqual (new FileInfo ("MyFile.txt"), new FileInfo ("MyFile.txt"));
			FileAssert.AreEqual ("MyFile.txt", "MyFile.txt");
			FileAssert.AreNotEqual (new FileInfo ("MyFile.txt"), new FileInfo ("MyFile2.txt"));
			FileAssert.AreNotEqual ("MyFile.txt", "MyFile2.txt");
			FileAssert.AreNotEqual (new FileStream ("MyFile.txt", FileMode.Open), new FileStream ("MyFile2.txt", FileMode.Open));
	

			// Utilities: will cause the test to stop immediatly and mark the test as:
			Assert.Pass ();   		
			Assert.Fail (); 		 
			Assert.Ignore (); 		
			Assert.Inconclusive ();

			// Defining the failed message
			Assert.IsTrue(true, "A failed message here"); // also object[] params can be defined
		}

		/// <summary>
		/// Constraint based testing: Test cases with a fluent design pattern
		/// </summary>
		[Test()]
		[Category("Constraint based testing")]
		public void TestConstraints ()
		{

			// Numerical Equality
			Assert.That (1, Is.EqualTo (1));
			Assert.That (1, Is.Not.EqualTo (2));
			Assert.That (1.1, Is.EqualTo (1.2).Within (0.1)); // Allow a tollerance
			Assert.That (1.1, Is.EqualTo (1.01).Within (10).Percent); // Pass tollerance within percent

			// Float Equality
			Assert.That (20000000000000004.0, Is.EqualTo (20000000000000000.0).Within (1).Ulps); // Pass tollerance with units of last place

			// String Equality
			Assert.That ("Foo!", Is.EqualTo ("Foo!"));
			Assert.That ("Foo!", Is.Not.EqualTo ("FOO!"));
			Assert.That ("Foo!", Is.EqualTo ("FOO!").IgnoreCase);
			Assert.That (new List<string> (){ "FOO!"}, Is.EqualTo (new List<string> (){ "Foo!"}).IgnoreCase);

			// Date, Time and TimeSpan equality
			Assert.That (DateTime.Today, Is.EqualTo (DateTime.Today));
			Assert.That (DateTime.Now, Is.Not.EqualTo (DateTime.Now));
			Assert.That (DateTime.Now, Is.EqualTo (DateTime.Now).Within (TimeSpan.FromSeconds (1))); // Time based pass tollerances
			Assert.That (DateTime.Now, Is.EqualTo (DateTime.Now).Within (1).Days);
			Assert.That (DateTime.Now, Is.EqualTo (DateTime.Now).Within (1).Hours);
			Assert.That (DateTime.Now, Is.EqualTo (DateTime.Now).Within (1).Minutes);
			Assert.That (DateTime.Now, Is.EqualTo (DateTime.Now).Within (1).Seconds);
			Assert.That (DateTime.Now, Is.EqualTo (DateTime.Now).Within (1).Milliseconds);

			// Collection equality
			Assert.That (new double[] {1.0,2.0,3.0}, Is.EqualTo (new int[] {1,2,3}));
			Assert.That (new double[] {1.0,2.0,3.0}, Is.Not.EqualTo (new int[] {1,2,3, 4}));
			Assert.That (new double[] {1.0,2.0,3.0,4.0}, Is.EqualTo (new  int[,] {{1,2}, {3,4}}).AsCollection); // Compare data and not collection (flattens a collection of collections)
		
			// Customer Comparer
			Assert.That( int.MinValue, Is.EqualTo(int.MaxValue).Using(new WhoCaresComparer())); 

			// Identity (Same instance of)
			Assert.That( string.Empty, Is.SameAs(string.Empty));
			Assert.That( new object(), Is.Not.SameAs(new object()));

			// Condition
			Assert.That( string.Empty, Is.Not.Null);
			Assert.That( true, Is.True);
			Assert.That( true, Is.Not.False);
			Assert.That( double.NaN, Is.NaN);
			Assert.That( string.Empty, Is.Empty);
			Assert.That( new List<int>(), Is.Empty);
			Assert.That( new List<int>(){1,2,3}, Is.Unique);

			// Comparision
			Assert.That(1, Is.LessThan(2));
			Assert.That(1, Is.GreaterThan(0));
			Assert.That(1, Is.LessThanOrEqualTo(1));
			Assert.That(1, Is.GreaterThanOrEqualTo(1));
			Assert.That(1, Is.AtLeast(0));	// Same as GreaterThanOrEqualTo
			Assert.That(1, Is.AtMost(2)); 	// Same as LessThanOrEqualTo
			Assert.That(1, Is.InRange(1,2));

			// Path: comparision on file path only without comparing the contents.
			// All paths are converted to 'canonical' path before comparing; full direct path to file.
			Assert.That( "MyFile.txt", Is.SamePath("MyFile.txt"));
			Assert.That( "MyFile.txt", Is.SamePath( "MYFILE.TXT" ).IgnoreCase );
			Assert.That( "MyFile.txt", Is.SamePath("MyFile.txt").RespectCase);
			Assert.That( "/usr/bin", Is.SubPath("/usr"));			// directory exists within another 
			Assert.That( "/usr/bin", Is.SamePathOrUnder("/usr"));	// SamePath or SubPath

			// Type Constraints
			Assert.That(new MemoryStream(), Is.InstanceOf(typeof(Stream)));  // Is type or ancestor
			Assert.That(new MemoryStream(), Is.TypeOf(typeof(MemoryStream))); // Is type and not ancestor
			Assert.That(new object(), Is.AssignableFrom(typeof(MemoryStream))); // Can be assigned from
			Assert.That(new MemoryStream(), Is.AssignableTo(typeof(Stream))); // Can be assignable to
	
			Assert.That(new MemoryStream(), Is.InstanceOf<Stream>());  // Is type or ancestor
			Assert.That(new MemoryStream(), Is.TypeOf<MemoryStream>()); // Is type and not ancestor
			Assert.That(new object(), Is.AssignableFrom<MemoryStream>()); // Can be assigned from
			Assert.That(new MemoryStream(), Is.AssignableTo<Stream>()); // Can be assignable to


			// String Comparision
			Assert.That( "Foo", Is.StringContaining( "o" ) );
			Assert.That( "Foo", Is.StringContaining( "O" ).IgnoreCase );
			Assert.That( "Foo", Is.StringStarting( "F" ) );
			Assert.That( "Foo", Is.StringEnding( "o" ) );
			Assert.That( "Foo", Is.StringMatching( "^[F]" ) ); // Regular ecpression match

			// Collection Comparison
			Assert.That( new List<int>(){1,2,3}, Has.All.GreaterThan(0) );
			Assert.That( new List<int>(){1,2,3}, Is.All.GreaterThan(0) );
			Assert.That( new List<int>(){1,2,3}, Has.None.GreaterThan(4));
			Assert.That( new List<int>(){1,2,3}, Has.Some.GreaterThan(2));
			Assert.That( new List<int>(){1,2,3}, Has.Count.EqualTo(3));
			Assert.That( new List<int>(){1,2,3}, Is.Unique);
			Assert.That( new List<int>(){1,2,3}, Has.Member(1));  // Contains
			Assert.That( new List<int>(){1,2,3}, Is.EquivalentTo( new List<int>(){3,2,1})); // Same data without carring about the order
			Assert.That( new List<int>(){1,2,}, Is.SubsetOf( new List<int>(){3,2,1})); // All are cotained.
		

			// Property Constraint
			Assert.That( new List<int>(), Has.Property("Count").EqualTo(0));  // Checks public property
			Assert.That( new List<int>(), Has.Count.EqualTo(0));			  // Same as Has.Property("Count").EqualTo(0)
			Assert.That( string.Empty, Has.Length.EqualTo(0));				  // Same as Has.Property("Length").EqualTo(0)
			Assert.That ( new Exception("Foo"), Has.Message.EqualTo("Foo"));  // Exception has message	
			Assert.That ( new Exception("Foo", new ArgumentException("Moo")), // Inner exception is of type and has message	
			             Has.InnerException.InstanceOf<ArgumentException>().And.InnerException.Message.EqualTo("Moo"));

			// Throws Constraint
			// See also Property constrains for Message and Inner Exception
			// Throws.Exception allow AND, Throws.InstanceOf<> is short hand
			Assert.That (() => { throw new ArgumentException("Foo"); }, 
				Throws.Exception.InstanceOf<ArgumentException>().And.Message.EqualTo("Foo"));

			Assert.That (() => { throw new ArgumentNullException("Foo"); }, 
				Throws.Exception.TypeOf<ArgumentNullException>());

			Assert.That (() => { throw new ArgumentNullException("Foo"); }, 
				Throws.InstanceOf<ArgumentNullException>());

			Assert.That (() => { }, Throws.Nothing);

			Assert.That (() => { throw new Exception("Foo", new ArgumentException("Moo"));}, 
				Throws.Exception.Message.EqualTo("Foo").And.InnerException.InstanceOf<ArgumentException>());

			Assert.That (() => { throw new ArgumentException(); }, Throws.ArgumentException);

			// Compound Constraints
			Assert.That( 2, Is.Not.EqualTo( 1 ));
			Assert.That( new List<int>(){ 1, 2, 3 }, Is.All.GreaterThan( 0 ) );

			Assert.That( 1, Is.GreaterThan( 0 ).And.LessThan( 2 ) );  // .And amd & are the same
			Assert.That( 1, Is.GreaterThan( 0 ) & Is.LessThan( 2 ) );

			Assert.That( 1, Is.LessThan( 10 ) | Is.GreaterThan( 0 ) ); // .Or and | are the same
			Assert.That( 1, Is.LessThan( 10 ).Or.GreaterThan( 0 ) ); 
	
			// Delayed
			Assert.That(() => { return true;}, Is.True.After(10));		// Passes after x time
			Assert.That(() => { return true;}, Is.True.After(10, 10));	// Passes after x time and polling..

			// List Mapper
			Assert.That(List.Map(new List<string>(){"1", "22", "333"}).Property("Length"),  // Allows all elememts in a list to have a condition provided for them
			            Is.EqualTo(new List<int>(){1,2,3}));
		}
	}
	# region Elements consumed by the tests above
	public class WhoCaresComparer : IEqualityComparer<int>
	{
	    public bool Equals(int b1, int b2)
	    {
			return true;
	    }

	    public int GetHashCode(int aNumber)
	    {
			return aNumber.GetHashCode();
	    }
	}

	public class ReverseComparer : IComparer
	{
		public int Compare (object a, object b)
		{
			return ((int)b).CompareTo((int)a);
		}
	}


	public enum CustomPropertyValue
	{
    	One,
    	Two,
   	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class CustomPropertyAttribute : PropertyAttribute
	{
    	public CustomPropertyAttribute( CustomPropertyValue value ) : base( "Custom", value.ToString() )
		{
		}
	}
	#endregion 
}
