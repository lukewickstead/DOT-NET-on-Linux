using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;
namespace GenericsExamples.Tests
{
    public class AccountTests : IDisposable,                             // Allows Test TearDown via Dispose()
                                IUseFixture<AccountTests.TestSetUpClass> // Allows Test Set Up via injected class
    {

        public AccountTests()
        {
            // TestFixture Setup code here
            Console.WriteLine("AccountTests Constructor");
        }

        public void SetFixture(TestSetUpClass setupClass)
        {
            // Can inject a class to provide any set up here.
            setupClass.AnyFunction();
        }
        /// <summary>
        /// The very simply example.
        /// </summary>
        [Fact]
        public void SimpleExample()
        {
            Console.WriteLine("AccountTests.TestOne()");
            Assert.True(true);
        }

        /// <summary>
        /// InLineData allows multiple traversals of the same test with different parameters
        /// </summary>
        /// <param name="number"></param>
        /// <param name="expectedResult"></param>
        [Theory,
        InlineData(1, true),
        InlineData(2, true),
        InlineData(3, false)]
        public void InlineDataExample(int number, bool expectedResult)
        {
            Console.WriteLine("AccountTests.DemoSimpleTestWithInLineData(int {0}, bool {1})", number, expectedResult);
            Assert.Equal(number < 3, expectedResult);
        }

        /// <summary>
        /// Properties returning IEnumerable can be used instead of InLineData.
        /// </summary>
        public static IEnumerable<object[]> SamplePropertyDataProperty
        {
            get
            {
                yield return new object[] { 1, true };
                yield return new object[] { 2, true };
                yield return new object[] { 3, false };
            }
        }

        /// <summary>
        /// PropertyData allow multiple calls of a test function with parameters defined in a property usign yield
        /// </summary>
        /// <param name="number">Test data</param>
        /// <param name="expectedResult">Expected Result</param>
        [Theory]
        [PropertyData("SamplePropertyDataProperty")]
        public void PropertyDataExample(int number, bool expectedResult)
        {
            Console.WriteLine("AccountTests.PropertyDataExample(int {0}, bool {1})", number, expectedResult);
            Assert.Equal(number < 3, expectedResult);
        }

        /// <summary>
        /// A run throw of the most common Assertions
        /// </summary>
        [Fact]
        public void AsertionExamples()
        {
            Console.WriteLine("AccountTests.AsertionExamples()");

            Assert.Contains("n", "FNZ", StringComparison.CurrentCultureIgnoreCase);
            Assert.Contains("a", new List<String> { "A", "B" }, StringComparer.CurrentCultureIgnoreCase);

            Assert.DoesNotContain("n", "FNZ", StringComparison.CurrentCulture);
            Assert.DoesNotContain("a", new List<String> { "A", "B" }, StringComparer.CurrentCulture);

            Assert.Empty(new List<String>());
            Assert.NotEmpty(new List<String> { "A", "B" });

            Assert.Equal(1, 1);
            Assert.Equal(1.13, 1.12, 1); // Precsions Num DP
            Assert.Equal(new List<String> { "A", "B" }, new List<String> { "a", "b" }, StringComparer.CurrentCultureIgnoreCase);
            Assert.Equal(GetFoo(1, "A Name"), GetFoo(1, "a name"), new FooComparer());
         
            Assert.NotEqual(1, 2);
            Assert.NotEqual(new List<String> { "A", "B" }, new List<String> { "a", "b" }, StringComparer.CurrentCulture);

            Assert.False(false);
            Assert.NotNull(false);
            Assert.Null(null);
            Assert.True(true);

            Assert.InRange(1, 0, 10);
            Assert.NotInRange(-1, 0, 10);

            Assert.IsType(Type.GetType("System.Int32"), 1);
            Assert.IsNotType(Type.GetType("System.Double"), 1);

            var foo = new object();
            var moo = new object();

            Assert.Same(foo, foo);
            Assert.NotSame(foo, moo);

            Assert.Throws<Exception>(() => { throw new Exception(); });
            Assert.True(true);
        }

        private static Foo GetFoo(int id, string name)
        {
            return new Foo { ID = id, Name = name };
        }

        public void Dispose()
        {
            // TestFixture Teardown attributes
            Console.WriteLine("AccountTests.Dispose()");
        }

        # region Internal Classes
        public class Foo
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        public class FooComparer : IEqualityComparer<Foo>
        {
            public bool Equals(Foo x, Foo y)
            {
                return x.ID == y.ID && x.Name.Equals(y.Name, StringComparison.CurrentCultureIgnoreCase);
            }

            public int GetHashCode(Foo obj)
            {
                return obj.ID.GetHashCode();
            }
        }

        public class TestSetUpClass
        {
            public void AnyFunction()
            {
                Console.WriteLine("TestSetUpClass.AnyFunction()");
            }
        }  
        #endregion
    }
}


