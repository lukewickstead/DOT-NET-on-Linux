using System;
using NUnit.Framework;

namespace Advanced.Delegates.Tests
{
    public class ActionFuncAndPredicate
    {
        // We have predefined delegate types of the most common method signatures. There are three types

        // Func<>
        // Predicate<>
        // Action<>

        /// <summary>
        /// Func is a method which can takes parameters of type T and returns a type TResult
        /// </summary>
        [Test]
        public void FuncExamples()
        {
            
            // Parameters expecting  a Func will looks something like
            // Func<TResult>
            // Func<T, TResult>
            // Func<T, T, TResult>
            // Func<T, T, T, TResult>
            // Func<T, T, T..... TResult>


            Func<int, int, string> aHandler = delegate(int aInt, int bInt) { return string.Empty; };
            Func<int, int, string> bHandler = (anInt, anotherInt) => { return string.Empty; };
            Func<int, int, string> cHandler = (anInt, anotherInt) => string.Empty;
        
            Func<string> dHandler = delegate() { return string.Empty; };
            Func<string> eHandler = () => string.Empty; // no parameters requires () unlike entities with only one parameter. when there is a return type we don't need {}
            
            Assert.AreEqual(string.Empty, aHandler(0, 0));
            Assert.AreEqual(string.Empty, bHandler(0, 0));
            Assert.AreEqual(string.Empty, cHandler(0, 0));
            Assert.AreEqual(string.Empty, dHandler());
            Assert.AreEqual(string.Empty, eHandler());
        }


        /// <summary>
        /// Predicate is a method which takes one element of Type T and returns a boolean
        /// Predicate in English means "To assert something"
        /// It does not contian any parametersless method signatures
        /// </summary>
        [Test]
        public void PredicateExamples()
        {
            // Parameters expecting  a Predicate will looks something like
            // Predicate<T, TResult>
            // Predicate<T, T, TResult>
            // Predicate<T, T, T, TResult>
            // Predicate<T, T, T..... TResult>


            Predicate<int> aHandler = delegate(int anInt) { return anInt > 1; };
            Predicate<int> bHandler = anInt => { return anInt > 1; };   // with only one parameter we don't need () surrounding the parameters
            Predicate<int> cHandler = anInt => anInt > 1;

            Assert.AreEqual(true, aHandler(2));
            Assert.AreEqual(true, bHandler(2));
            Assert.AreEqual(true, cHandler(2));
            
            Assert.AreEqual(false, aHandler(1));
            Assert.AreEqual(false, bHandler(1));
            Assert.AreEqual(false, cHandler(1));
        }

        /// <summary>
        /// Action is a method with at least one parameters which returns void
        /// </summary>
        [Test]
		[ExpectedException]
		public void ActionDelegateExample()
        {
            Action<int> aHandler = delegate(int x) { throw new Exception(); };
			aHandler(1); 
        }

		/// <summary>
		/// Action is a method with at least one parameters which returns void
		/// </summary>
		[Test]
		[ExpectedException()]
		public void ActionLambdaExample()
		{
			Action<int> aHandler = x => { throw new Exception(); };
			aHandler(1);
		}
    }
}
