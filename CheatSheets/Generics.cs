
// **** WHY GENERICS ****
// Type Safe: Prevent having to cast between obect and a type when retrieving data from objects such as classes

// Faster: Value types which are placed into classes which are designed to be used on multiple types. No need to box/unbox value types. 
// Allocating an object on the heap from the stack and vice versa is slow

// **** WHEN SHOULD I USE GENERICS ****
// When you have multiple method overloads which have the same functionality for multiple types

// *** WHEN SHOULD I NOT USE GENERICS ****
// If you find yourself restrcting access to an Interface or a base class then you should ask yourself if generics is really required here


// **** CONSTRAINTS ****
// Constrains provide a way to limit which types can be used
// In most cases no constraintss should be used 
where T: struct 	// Value Type; System.ValeValue is found as an ancestor
where T: class 		// Reference type; System.ValeValue is not found as an ancestor (any class, interface, delegate or array type)
where T: new() 		// Provides a parameterless constructor.
where T: <ClassName> 	// Has an ancestory
where T: <IFaceName> 	// Implements an interface
where T: U 		// One provided type is an ancestor of another.

// Examples
class Test<T, U> where U : struct where T : Base, new() {}
class List<T>{ void Add<U>(List<U> items) where U : T {}
class SampleClass<T, U, V> where T : V {}
void SomeFunction<T>(T aValue) where T : V {}

// **** EQUALITY  ****
// Can not use != & == operators as we can not gurantee that concrete type will implement these
// Can compare to null though for value types will always return false.
  
// **** DEFAULT VALUE ****
return default(T); // returns the default value of the type; 0 for int etc.

// **** CASTING ****   
// Can cast to and from System.Object and explcitly convert to any interfaces.
// Implicit cast can be to object or to constraint-specified types only.
// Implicit casting is type safe as incompatibility is discovered at compile-time. 
// Explicit cast can be to interface only

// Consider
class MyClass<T> where T : BaseClass, ISomeInterface {}

//Implicit      
ISomeInterface obj1 = t;      
BaseClass      obj2 = t;      
object         obj3 = t;

// Explicit
ISomeInterface obj1 = (ISomeInterface)t;	//Compiles      
SomeClass      obj2 = (SomeClass)t;     	//Does not compile
 
// Explcity achieved via temp object; is dangerous. better to use is or as operator
object temp = t;
MyOtherClass obj = (MyOtherClass)temp;

// Can Cast
bool IsInterface = typeof(ISomeInterface).IsAssignableFrom(typeof(T));
if(t is int)
if(t is LinkedList<int,string>)

// AS Cast; like a cast but returns null on failure
t as IDisposable
expression is type ? (type)expression : (type)null // equivalent to as
using(t as IDisposable)      
  
// **** ATTRIBUTES ****
// These can not be used however you can check owning functions
myobj.GetType().IsSerializable  

// **** TYPE ANALYSYS ****

// TypeCode Enum
TypeCode typeCode = Type.GetTypeCode( testObject.GetType() );
TypeCode.Boolean;
TypeCode.Decimal;  

// IsType
typeof(int).IsPrimitive 
typeof(int).IsDecimal
typeof(int).IsArray
typeof(int).IsInterface 

// Nullable Types
Nullable<t>
t?

// **** CONVERTING BETWEEN TYPES ****
// Parse & Try Parse
Integer.Parse
Integer.TryParse( "1", out aValue)

// Change Type: Returns an object of the specified type and whose value is equivalent to the specified object.
int i = (int)Convert.ChangeType(-2.345, typeof(int));
DateTime dt = (DateTime)Convert.ChangeType("12/12/98", typeof(DateTime));

// TypeDescriptor Converter
public static T GetTfromString<T>(string mystring)
{
   var foo = TypeDescriptor.GetConverter(typeof(T));
   return (T)(foo.ConvertFromInvariantString(mystring));
}
