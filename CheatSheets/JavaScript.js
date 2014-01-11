

// Java Script Basics
document.write("<p>Hello!</p>");
name = prompt ("Please Enter Your Name.","Your Name Goes Here");

// ******** ARRAYS ******** 
var foo = [1,2,3];
var foo = new Array( 1,2,3);
foo[2]; 
foo[2]=3;  
foo.length;
foo.push(4);  					// adds an element at the end
foo.push(5,6,7) 				// can take more than one element
foo.unshift(0); 				// adds an element at the beginning
var lastEl = foo.pop(); 		        // gets and removes last element
var firstEl = foo.shift(); 		        // gets and remove first element
var array.splice(index,howMany,e1,e2,ex) 	// adds and or removes elements. Returns remove elements
document.write(arrayFoo); 		        // writes comma separated to documented
foo.concat()  					// joins two or more arrays, and returns a copy of the joined arrays
foo.join() 					// joins all elements of an array into a string
foo.reverse() 					// reverses the order of the elements in an array
foo.slice() 					// Selects a part of an array, and returns the new array
foo.sort() 					// sorts the elements of an array
foo.toString() 					// converts an array to a string, and returns the result
foo.valueOf() 					// returns the primitive value of an array


// ******** LOOPS ********

for (i=0;i<=5;i++){}   		// for
while (i<=5){i++;}		// while
do{i++;} while (i<=5);		// do while 
for (x in foo) {foo[x]};	// for in
break; 				// stop loop
continue; 			// continue next iteration
  
  
// ******** TRY CATCH THROW ********  

try {	} catch(err) {	txt = err.description; }
try {	throw "Err1"; } catch(er)
{
  if(er=="Err1")
  {	alert("Error! The value is too high");
  }
}

// ******** CHARACTERS / STRING ********
// Escape characters 
var txt="We are the so-called "Vikings" from the north."; 

"\'"  	// single quote
"\"" 	// double quote
"\&" 	// ampersand
"\\" 	// backslash
"\n" 	// new line
"\r" 	// carriage return
"\t" 	// tab
"\b" 	// backspace
"\f" 	// form feed

"".charAt() 				// Returns the character at the specified index
"".charCodeAt() 	 		// Returns the Unicode of the character at the specified index
"".concat() 				// Joins two or more strings, and returns a copy of the joined strings
"".fromCharCode() 		        // Converts Unicode values to characters
"".indexOf() 				// Returns the position of the first found occurrence of a specified value in a string
"".lastIndexOf() 			// Returns the position of the last found occurrence of a specified value in a string
"".match() 				// Searches for a match between a regex and a string, and returns the matches
"".replace() 				// Searches for a match between a substring (or regex) and a string, and replaces
"".search() 				// Searches for a match between a regular expression and a string, and returns the position of the match
"".slice() 				// Extracts a part of a string and returns a new string
"".split() 				// Splits a string into an array of substrings
"".substr() 				// Extracts the characters from a string, beginning at a specified start position, and through the specified number of character
"".substring() 				// Extracts the characters from a string, between two specified indices
"".toLowerCase() 			// Converts a string to lowercase letters
"".toUpperCase() 			// Converts a string to uppercase letters
"".valueOf() 				// Returns the primitive value of a String object



// ******** DATE / TIME ********
today = new Date()
d1 = new Date("October 13, 1975 11:13:00")
d2 = new Date(79,5,24)
d3 = new Date(79,5,24,11,33,0)
myDate.setFullYear(2010,0,14)
myDate.setDate(myDate.getDate()+5);


getDate() 			// Returns the day of the month (from 1-31)
getDay() 			// Returns the day of the week (from 0-6)
getFullYear() 			// Returns the year (four digits)
getHours() 			// Returns the hour (from 0-23)
getMilliseconds() 	        // Returns the milliseconds (from 0-999)
getMinutes() 			// Returns the minutes (from 0-59)
getMonth() 			// Returns the month (from 0-11)
getSeconds() 			// Returns the seconds (from 0-59)
getTime() 			// Returns the number of milliseconds since midnight Jan 1, 1970
getTimezoneOffset() 	 	// Returns the time difference between GMT and local time, in minutes
Date.parse(datestring)		// Parse
setDate()  			// Sets the day of the month (from 1-31)
setFullYear() 			// Sets the year (four digits)
setHours() 			// Sets the hour (from 0-23)
setMilliseconds() 	        // Sets the milliseconds (from 0-999)
setMinutes() 			// Set the minutes (from 0-59)
setMonth() 			// Sets the month (from 0-11)
setSeconds() 			// Sets the seconds (from 0-59)
setTime() 			// Sets a date and time by adding or subtracting a specified number of milliseconds to/from midnight January 1, 1970
toDateString()  		// Converts the date portion of a Date object into a readable string
toDateString()  		// Converts the date portion of a Date object into a readable string
toGMTString() 			// Deprecated. Use the toUTCString() method instead
toLocaleDateString() 		// Returns the date portion of a Date object as a string, using locale conventions
toLocaleTimeString() 		// Returns the time portion of a Date object as a string, using locale conventions
toLocaleString() 		// Converts a Date object to a string, using locale conventions
toString() 			// Converts a Date object to a string
toTimeString() 			// Converts the time portion of a Date object to a string

// ******** NUMBER ********

Number.NaN
toExponential(x)  	 	// Converts a number into an exponential notation
toFixed(x) 			// Formats a number with x numbers of digits after the decimal point
toPrecision(x) 			// Formats a number to x length
toString() 			// Converts a Number object to a string
valueOf() 			// Returns the primitive value of a Number object

// ******** MATH ********

// Math.Constants
E 				// Returns Eulers number (approx. 2.718)
LN2 				// Returns the natural logarithm of 2 (approx. 0.693)
LN10 			     	// Returns the natural logarithm of 10 (approx. 2.302)
LOG2E 			    	// Returns the base-2 logarithm of E (approx. 1.442)
LOG10E 		        	// Returns the base-10 logarithm of E (approx. 0.434)
PI 				// Returns PI (approx. 3.14159)
SQRT1_2 	        	// Returns the square root of 1/2 (approx. 0.707)
SQRT2 			    	// Returns the square root of 2 (approx. 1.414)


// Math.Methods
abs(x) 				// Returns the absolute value of x
acos(x) 			// Returns the arccosine of x, in radians
asin(x) 			// Returns the arcsine of x, in radians
atan(x) 			// Returns the arctangent of x as a numeric value between -PI/2 and PI/2 radians
atan2(y,x) 			// Returns the arctangent of the quotient of its arguments
ceil(x) 			// Returns x, rounded upwards to the nearest integer
cos(x) 				// Returns the cosine of x (x is in radians)
exp(x) 				// Returns the value of Ex
floor(x) 			// Returns x, rounded downwards to the nearest integer
log(x) 				// Returns the natural logarithm (base E) of x
max(x,y,z,...,n) 		// Returns the number with the highest value
min(x,y,z,...,n) 		// Returns the number with the lowest value
pow(x,y) 			// Returns the value of x to the power of y
random() 			// Returns a random number between 0 and 1
round(x) 			// Rounds x to the nearest integer
sin(x) 				// Returns the sine of x (x is in radians)
sqrt(x) 			// Returns the square root of x
tan(x) 				// Returns the tangent of an angle


// ******** GLOBAL *******

// Properties
Infinity 			// A numeric value that represents positive/negative infinity
NaN 				// "Not-a-Number" value
undefined 			// Indicates that a variable has not been assigned a value


// Functions 	
decodeURI() 		    	// Decodes a URI
decodeURIComponent() 		// Decodes a URI component
encodeURI() 			// Encodes a URI
encodeURIComponent() 		// Encodes a URI component
escape() 			// Encodes a string
eval() 				// Evaluates a string and executes it as if it was script code
isFinite() 			// Determines whether a value is a finite, legal number
isNaN() 			// Determines whether a value is an illegal number
Number() 			// Converts an object's value to a number
parseFloat() 			// Parses a string and returns a floating point number
parseInt() 			// Parses a string and returns an integer
String() 			// Converts an object's value to a string
unescape() 			// Decodes an encoded string

