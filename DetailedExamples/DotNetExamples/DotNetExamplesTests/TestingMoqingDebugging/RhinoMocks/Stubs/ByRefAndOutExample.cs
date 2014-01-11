namespace TestingMoqingDebugging.RhinoMocks.Tests
{
	using System;
	using NUnit.Framework;
	using Rhino.Mocks;
	using RIS = Rhino.Mocks.Constraints.Is;

	public class ByRefAndOutExample
	{
		[Test]
		public void RefExample ()
		{
			int refValue = 0;

			var sut = MockRepository.GenerateStub<ISimpleModel> ();
			sut.Stub (x => x.Do (Arg<int>.Is.Equal (1), ref Arg<int>.Ref (RIS.Equal (0), 10).Dummy)).Return (1);
       
			var value = sut.Do (1, ref refValue);

			Assert.That (value.Equals (1));
			Assert.That (refValue.Equals (10));
		}

		[Test]
		public void OutExample ()
		{
			int outValue = 0;

			var sut = MockRepository.GenerateStub<ISimpleModel> ();

			sut.Stub (x => x.Do (Arg<int>.Is.Equal (1), Arg<string>.Is.Equal ("Hello"), out Arg<int>.Out (10).Dummy)).Return (1);
       
			var value = sut.Do (1, "Hello", out outValue);

			Assert.That (value.Equals (1));
			Assert.That (outValue.Equals (10));
		}
	}
}