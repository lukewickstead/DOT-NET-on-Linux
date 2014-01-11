using NUnit.Framework;

namespace Advanced.Delegates.Tests
{
    public class EventExample
    {
        // Delegae provides a type sage memmory allocation to a function
        public delegate bool IsGreaterThan(int aValue, int compareTo);

        public event IsGreaterThan IsGreaterThanEvent;

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
        public void TestEvent()
        {

            IsGreaterThanEvent += IsGreaterThanImplementation;
            IsGreaterThanEvent += IsGreaterOrEqual;

            TestIsGreaterThanDelegate(IsGreaterThanEvent);
        }

        private static void TestIsGreaterThanDelegate(IsGreaterThan isGreaterThanHandler)
        {
            // Only the last delegate in the stack can return a value
			Assert.IsTrue(isGreaterThanHandler(1, 1));
			Assert.IsTrue(isGreaterThanHandler(0, 0));
			Assert.IsTrue(isGreaterThanHandler(2, 2));
        }
    }
}


