using NUnit.Framework;

namespace Advanced.Delegates.Tests
{
    public class DelegatesToLambda
    {
        // Delegate provides a type sage memmory allocation to a function
        public delegate bool IsGreaterThan(int aValue, int compareTo);

        public static bool IsGreaterThanImplementation(int aValue, int compareTo)
        {
            return aValue > compareTo;
        }

        /// <summary>
        /// Delegate creation and assignment - PRovide an instance of a delegate against a method with a compliant signature 
        /// </summary>
        [Test]
        public void Test01CreateADelegateInstance()
        {
            IsGreaterThan isGreaterThanHandler = new IsGreaterThan(DelegatesToLambda.IsGreaterThanImplementation);

            TestIsGreaterThanDelegate(isGreaterThanHandler);
        }

        /// <summary>
        /// Method Group Conversion - Provide a method group and not an instance of a delegare
        /// The method with the correct signature is automatically used to create an instance of the delegate
        /// </summary>
        [Test]
        public void Test02MethodGroupConversion()
        {
            IsGreaterThan isGreaterThanHandler = IsGreaterThanImplementation;

            TestIsGreaterThanDelegate(isGreaterThanHandler);
        }

        /// <summary>
        /// Anonymous Method - Provide an anonymous function as a delegate
        /// </summary>
        [Test]
        public void Test03AnonymousFunction()
        {
            IsGreaterThan isGreaterThanHandler = delegate(int aValue, int compareTo) { return aValue > compareTo; };

            TestIsGreaterThanDelegate(isGreaterThanHandler);
        }

        /// <summary>
        /// Lambda Function - Provide a lambda function as a delegate
        /// </summary>
        [Test]
        public void Test04LambdaFunction()
        {
            IsGreaterThan isGreaterThanHandler = (aValue, compareTo) => aValue > compareTo;

            TestIsGreaterThanDelegate(isGreaterThanHandler);
        }

        private static void TestIsGreaterThanDelegate(IsGreaterThan isGreaterThanHandler)
        {
			Assert.IsTrue(isGreaterThanHandler(1, 0));
			Assert.IsFalse(isGreaterThanHandler(0, 0));
			Assert.IsFalse(isGreaterThanHandler(0, 1));
        }
    }
}