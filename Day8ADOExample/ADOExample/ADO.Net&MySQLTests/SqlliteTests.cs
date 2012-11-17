using ADODotNetAndMySQL.DAL.ADOProviders;
using ADODotNetAndMySQL.DAL.Models;
using ADODotNetAndMySQL.DAL.Repositories;
using ADODotNetAndMySQL.Utils;
using Ninject;
using NUnit.Framework;	
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADODotNetAndMySQLTests
{
	[TestFixture()]
	public class SqlliteTests
	{
		[TestFixtureSetUp]
		public void PreTestInitialize ()
		{
			InjectionFactory.Instance.SetDbProvider (InjectionFactory.DbProbvider.Sqllite);
		}

		[Test()]
		public void TestCanCount ()
		{
			DBTests.TestCanCount ();
		}

		[Test()]
		public void TestCanDelete ()
		{
			DBTests.TestCanDelete ();
		}

		[Test()]
		public void TestCanDeleteAll ()
		{
			DBTests.TestCanDeleteAll ();
		}

		[Test()]
		public void TestCanInsert ()
		{
			DBTests.TestCanInsert ();
		}

		[Test()]
		public void TestCanUpdate ()
		{
			DBTests.TestCanUpdate ();
		}
	}
}
	
