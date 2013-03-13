namespace RhinoMocksExample.Stubs
{
    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    using RhinoMocksExample.Model;

    [TestFixture]   
    public class RepeatExample
    {   
        private ISimpleModel sut;

        public RepeatExample()
        {
            this.sut = MockRepository.GenerateStub<ISimpleModel>();
            this.sut.Stub(x => x.Do()).Return(1).Repeat.Once();
            this.sut.Stub(x => x.Do()).Return(2).Repeat.Twice();
            this.sut.Stub(x => x.Do()).Return(3).Repeat.Times(3);
            this.sut.Stub(x => x.Do()).Return(4).Repeat.Times(4);
        }

        [Test]
        public void WhenRepeatCalled()
        {
            int[] returns = { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };

            foreach (var val in returns)
            {
                Assert.That(this.sut.Do().Equals(val));
            }
        }
    }
}