using NUnit.Framework;

namespace SandBox.Tests.Delegates
{
    public class MulticastDelegateExample
    {
        // Delegae provides a type sage memmory allocation to a function
        public delegate bool IsGreaterThan(int aValue, int compareTo);

        public static bool IsGreaterThanImplementation(int aValue, int compareTo)
        {
            return aValue > compareTo;
        }

        public static bool IsGreaterOrEqual(int aValue, int compareTo)
        {
            return aValue >= compareTo;
        }


        /// <summary>
        /// Delegate creation and assignment - PRovide an instance of a delegate against a method with a compliant signature 
        /// </summary>
        [Test]
        public void TestMultiCastDelegate()
        {
            IsGreaterThan isGreaterThanHandler = IsGreaterThanImplementation;

            isGreaterThanHandler += IsGreaterOrEqual;

            TestIsGreaterThanDelegate(isGreaterThanHandler);
        }

        private static void TestIsGreaterThanDelegate(IsGreaterThan isGreaterThanHandler)
        {
            // Only the last delegate in the stack can return a value
            Assert.True(isGreaterThanHandler(1, 1));
            Assert.True(isGreaterThanHandler(0, 0));
            Assert.True(isGreaterThanHandler(2, 2));
        }
    }
}


