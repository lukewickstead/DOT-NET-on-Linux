using System;
using NUnit.Framework;

namespace Advanced.Delegates.Tests
{
    public class DelegatesToLambdaWithGlobalGenericsFunctions
    {
        // Delegate provides a type safe memmory allocation to a method

        public static string ConcatToStringImplementation(int aValue, int bValue)
        {
            return string.Format("{0}{1}", aValue, bValue);
        }

        /// <summary>
        /// Delegate creation and assignment - PRovide an instance of a delegate against a method with a compliant signature 
        /// </summary>
        [Test]
        public void Test01CreateADelegateInstance()
        {
            var concatToStringHandler = new Func<int,int, string>(DelegatesTestsWithGenerics.ConcatToStringImplementation);

            TestIsGreaterThanDelegate(concatToStringHandler);
        }

        /// <summary>
        /// Method Group Conversion - Provide a method group and not an instance of a delegare
        /// The method with the correct signature is automatically used to create an instance of the delegate
        /// </summary>
        [Test]
        public void Test02MethodGroupConversion()
        {
            Func<int, int, string> concatToStringHandler = DelegatesTestsWithGenerics.ConcatToStringImplementation;

            TestIsGreaterThanDelegate(concatToStringHandler);
        }

        /// <summary>
        /// Anonymous Method - Provide an anonymous function as a delegate
        /// </summary>
        [Test]
        public void Test03AnonymousFunction()
        {
            Func<int, int, string> concatToStringHandler = delegate(int aValue, int bValue) { return string.Format("{0}{1}", aValue, bValue); };

            TestIsGreaterThanDelegate(concatToStringHandler);
        }

        /// <summary>
        /// Lambda Function - Provide a lambda function as a delegate
        /// </summary>
        [Test]
        public void Test04LambdaFunction()
        {
            Func<int, int, string> concatToStringHandle = (aValue, compareTo) => string.Format("{0}{1}", aValue, compareTo);

            TestIsGreaterThanDelegate(concatToStringHandle);
        }

        private static void TestIsGreaterThanDelegate(Func<int, int, string> concatToStringHandler)
        {
            Assert.AreEqual("10", concatToStringHandler(1, 0));
            Assert.AreEqual("00", concatToStringHandler(0, 0));
            Assert.AreEqual("11", concatToStringHandler(1, 1));

        }
    }
}


