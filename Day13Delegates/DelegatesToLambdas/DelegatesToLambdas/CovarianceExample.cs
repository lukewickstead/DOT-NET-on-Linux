using NUnit.Framework;
using System;

namespace SandBox.Tests.Delegates
{
    public class Parent
    {
        public string ParentField { get; set; }
    }

    public class Child : Parent
    {
        public string ChildField { get; set; }
    }

    public class CovarianceExample
    {
        // Define the delegate.
        public delegate Parent ReutrnParent();

        public static Parent ReturnParent()
        {
            return new Parent {ParentField = "A Parent!"};
        }

        public static Child ReturnChild()
        {
            return new Child { ChildField = "A Child!", ParentField = "A Parent!" };
        }

        [Test]
        public static void TestCovariance()
        {
            ReutrnParent returnParent = ReturnParent;

            var aParent = returnParent();

            Assert.IsInstanceOf<Parent>(aParent);
            StringAssert.AreEqualIgnoringCase(aParent.ParentField, "A Parent!");

            // Covariance allows this delegate.
            ReutrnParent returnChild = ReturnChild;

            var aChild = returnChild() as Child;
            Assert.NotNull(aChild);
            Assert.IsInstanceOf<Child>(aChild);
            StringAssert.AreEqualIgnoringCase(aChild.ParentField, "A Parent!");
            StringAssert.AreEqualIgnoringCase(aChild.ChildField, "A Child!");
        }
    }
}


