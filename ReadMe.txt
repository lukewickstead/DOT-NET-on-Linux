*** The Blog

The source code contained in this repositority is from the blog http://lukewickstead.wordpress.com


*** The Book

The source code the my book concise C# is contained here in this repository.

The book is available on Amazon:

http://www.amazon.co.uk/Concise-C-Luke-Wickstead-ebook/dp/B00HP4BN82/ref=sr_1_1?ie=UTF8&qid=1389440178&sr=8-1&keywords=concise+C%23


*** Overview

The code can be split into three sections

01: Cheat Sheets. Consdensed cheat sheet notes.
02: Simple Introductions. Gentle examples without much coverage
03: Detailed Examples. An extensive look at the source code. Some APIs such as Linq, NUnit, NInject and RhinoMocks cover the vast majority of the funcitonality available.

Some of the examples are coded only in unit tests so please look in both the test and non test solution for the examples.

All code above is for demonstriation only and should not be considered well formed code.


*** Mono/MonoDevelop

For those who are using Mono/MonoDevelop; the latest Mono/MonoDevelop is packaged in the following reppository.
The only issue is that NUnit which comes pre packages misses the fluent extensions.
http://lukewickstead.wordpress.com/2014/01/04/install-latest-mono-monodevelop-under-linux/


*** NUnit

The NUnit details overview uses the older version of Mono/MonoDevelop which is currently sitting in Debian Testing as it comes packaged with a version of NUnit which has the fluent extensions


*** ADO.NET

An export of the MyDatabase can be found within Resources\MyDatabaseExport.sql. 
This was taken from MySQL though should work without any modifications within SQLServer.
Exports can be made by running:

	mysqldump -u root MyDatabase -p > MyDatabaseExport.sql

Instructions on how to set up MySQL with ADO.NET under Linux can be found here:
	
	http://lukewickstead.wordpress.com/2012/11/18/day-8-1-dot-net-on-linux-connecting-consuming-mysql-with-ado-net/


*** Event Log

Instructions on how to enable the Event Log under linux for use with Mono can be found here:

	http://lukewickstead.wordpress.com/2014/01/04/set-up-enable-the-event-log-under-mono-gnulinux


