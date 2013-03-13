// *** STUB ****
// A stub is an object which is required to pass the SUT.

mocks.CreateStub<T>(); 

// The simple stub
var sut = MockRepository.GenerateStub<ISimpleModel>();         
sut.Stub(x => x.Do()).Return(1);

// Stub Property
sut.Stub(x => x.AReadonlyPropery).Return(1); // Reaonly ( only get )
sut.AProperty = 2; // Stub Get

// Repeat
mock.Stub(x => x.Do()).Return(1).Repeat.Once();
mock.Stub(x => x.Do()).Return(2).Repeat.Twice();
mock.Stub(x => x.Do()).Return(3).Repeat.Times(3);

// Events
mock.Raise(x => x.Load += null, this, EventArgs.Empty);

// **** Arguments Conditional ****
// These can be used for Stub, Expect, AssertWasCalled and AssertWasNotCalled

// Ignore Arguments Conditional
sut.Stub(x => x.Do(Arg<int>.Is.Equal(1))).IgnoreArguments().Return(1);

// Is Conditionals
sut.Stub(x => x.Do(Arg<int>.Is.Anything)).Return(1);
sut.Stub(x => x.Do(Arg<int>.Is.Equal(1))).Return(1);
sut.Stub(x => x.Do(Arg<int>.Is.NotEqual(1))).Return(10);       
sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.Null)).Return(1);
sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.NotNull)).Return(2);
sut.Stub(x => x.Do(Arg<int>.Is.LessThanOrEqual(10))).Return(1);
sut.Stub(x => x.Do(Arg<int>.Is.GreaterThan(10))).Return(2);
sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.Same(foo))).Return(1);
sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.NotSame(foo))).Return(2);
sut.Stub(x => x.DoIFoo(Arg<Foo>.Is.TypeOf)).Return(1);      

// Matches Conditional
sut.Stub(x => x.Do(Arg<int>.Matches(y => y > 5))).Return(1);

// List Conditionals
sut.Stub(x => x.Do(Arg<List<int>>.List.Count(RIS.Equal(0)))).Return(0);
sut.Stub(x => x.Do(Arg<List<int>>.List.Element(0, RIS.Equal(1)))).Return(1);
sut.Stub(x => x.Do(Arg<List<int>>.List.Equal(new int[] { 4, 5, 6 }))).Return(2);
sut.Stub(x => x.Do(Arg<List<int>>.List.IsIn(1))).Return(1);
sut.Stub(x => x.Do(Arg<int>.List.OneOf(new int[] { 4, 5, 6 }))).Return(2);   

// ByRef and Out parameters 
sut.Stub(x => x.Do(Arg<int>.Is.Equal(1), ref Arg<int>.Ref(RIS.Equal(0), 10).Dummy)).Return(1);
sut.Stub(x => x.Do(Arg<int>.Is.Equal(1), Arg<string>.Is.Equal("Hello"), out Arg<int>.Out(10).Dummy)).Return(1);

// **** DYNAMIC MOCKS ***
// A mock is an object which we can set expectations on and will assert that those expectations have been 
// Dynamic Mock provides easier syntax and does not require stubbing/expecting all methods

mocks.CreateMock<T>(); 

// Assert Was Called
mock.AssertWasCalled(p => p.Add(Arg<AnotherModel>.Is.Anything));
mock.AssertWasCalled(p => p.Add(Arg<AnotherModel>.Is.NotNull));
mock.AssertWasCalled(p => p.Add(Arg<AnotherModel>.Is.Equal(theModel)));
mock.AssertWasNotCalled(p => p.Add(Arg<AnotherModel>.Is.Null));       
mock.AssertWasCalled(x => x.AReadonlyPropery);
mock.AssertWasCalled(x => x.AProperty);
mock.AssertWasCalled(x => x.AProperty = 9);
mock.AssertWasCalled(x => x.EventHandler += Arg<AnEvent>.Is.Anything); // Event was registered

// Expect & Verify
mock.Expect(p => p.Add(Arg<AnotherModel>.Is.Anything));
mock.Expect(p => p.Add(Arg<AnotherModel>.Is.NotNull));                    
mock.Expect(p => p.Add(Arg<AnotherModel>.Is.Equal(theModel)));
mock.Expect(x => x.AReadonlyPropery).Return(9);
mock.Expect(x => x.AProperty).Return(9);
mock.Expect(x => x.AProperty).SetPropertyAndIgnoreArgument();
mock.Expect(x => x.AProperty).SetPropertyWithArgument(11);

mock.VerifyAllExpectations()









