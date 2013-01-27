// DELEGATE DEFINITION
public delegate bool IsGreaterThan(int aParam, int compareTo);

// CREATION AND ASSIGNMENT

// .Net 1 version
IsGreaterThan isGreaterThanHandler = new IsGreaterThan(DelegatesToLambda.IsGreaterThanImplementation);

// Method Group Conversion
IsGreaterThan isGreaterThanHandler = IsGreaterThanImplementation;

// Anonymous Function
IsGreaterThan isGreaterThanHandler = delegate(int aValue, int compareTo) { return aValue > compareTo; };

// Lambda Functions
IsGreaterThan isGreaterThanHandler = (int aValue, int compareTo) => { return aValue > compareTo; }; // Full hand
IsGreaterThan isGreaterThanHandler = (aValue, compareTo) => { return aValue > compareTo; }; // Param type inferrence 
IsGreaterThan isGreaterThanHandler = (aValue, compareTo) => aValue > compareTo; // One line in method + return inferred
IsGreaterThan isGreaterThanHandler = aValue  => aValue > 1; // One param
IsGreaterThan isGreaterThanHandler = ()  => 2 > 1; // No params


// DELEGATES AND GENERICS

// Definition
public delegate string ConcatToString<T>(T aValue, T compareTo);

// .Net 1 version
ConcatToString<int> concatToStringHandler = new ConcatToString<int>(DelegatesTestsWithGenerics.ConcatToStringImplementation);

// Method Group Conversion
ConcatToString<int> concatToStringHandler = DelegatesTestsWithGenerics.ConcatToStringImplementation;

// Anonymous Function
ConcatToString<int> concatToStringHandler = delegate(int aValue, int bValue) { return string.Format("{0}{1}", aValue, bValue); };

// Lambda Function
ConcatToString<int> concatToStringHandle = (aValue, compareTo) => string.Format("{0}{1}", aValue, compareTo);


// FUNC<T, TResult>, ACTION<T> PREDICATE<T>

// Func, Action & Predicate are global delegates definitions to save creating your own.

// Func<T>
// Func can take up to 16 parameter types and return one type
  
// Parameters expecting  a Func will looks something like
// Func<TResult>
// Func<T, TResult>
// Func<T, T, TResult>
// Func<T, T, T, TResult>
// Func<T, T, T..... TResult>

Func<int, int, string> aHandler = delegate(int aInt, int bInt) { return string.Empty; }; // Anonymous Method
Func<int, int, string> cHandler = (anInt, anotherInt) => string.Empty; // Lambda

// Predicate<T> can take up to 16 parameters and retun a bool
// Parameters expecting  a Predicate will looks something like
// Predicate<T, TResult>
// Predicate<T, T, TResult>
// Predicate<T, T, T, TResult>
// Predicate<T, T, T..... TResult>

Predicate<int> aHandler = delegate(int anInt) { return anInt > 1; }; // Anonymous Method
Predicate<int> cHandler = anInt => anInt > 1; // Lambda

// Action<T> can take up to 16 parameters and retuns a null
// Parameters expecting  a Action will looks something like
// Predicate<T>
// Predicate<T, T>
// Predicate<T, T, T>
// Predicate<T, T, T....., T>

Action<int> aHandler = delegate(int x) { throw new Exception(); }; // Anonymous Method
Action<int> bHandler = x => { throw new Exception(); };       // Lambda


// MULTICAST DELEGATES
// Multiple events can be registered and deregistered with += and -=
// All events are called one at a time. 
// Last one returns the value.
IsGreaterThan isGreaterThanHandler = IsGreaterThanImplementation;
isGreaterThanHandler += IsGreaterOrEqual;
isGreaterThanHandler(1,2);
isGreaterThanHandler -= IsGreaterOrEqual;


﻿// EVENTS
// Events are shorthand notation of grouping delegates
public delegate bool IsGreaterThan(int aParam, int compareTo);
public event IsGreaterThan IsGreaterThanEvent;
IsGreaterThanEvent += IsGreaterThanImplementation;
IsGreaterThanEvent += IsGreaterOrEqual;
IsGreaterThanEvent(1,2);
IsGreaterThanEvent -= IsGreaterOrEqual;


// CONTRAVARIANCE 
Contravariance allows us to a method which has a parameter which is a child class of the defined parameter.

// COVARIANCE 
Allows us to return a type which is a child class of the defined delegate return type
        
