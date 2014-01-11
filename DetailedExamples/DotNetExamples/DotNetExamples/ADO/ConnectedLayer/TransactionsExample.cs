using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.ConnectedLayer
{
	public class TransactionsExample
	{
		public bool IsHit { get; private set; }

		public void WithTry ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmdOne = cn.CreateCommand ();
				cmdOne.CommandText = "delete from MyTable";
				cmdOne.Connection = cn;
				cmdOne.CommandType = CommandType.StoredProcedure;     

				var cmdTwo = cn.CreateCommand ();
				cmdTwo.CommandText = "delete from NonExisantTanble";
				cmdTwo.Connection = cn;
				cmdTwo.CommandType = CommandType.StoredProcedure;  

				var tran = cn.BeginTransaction ();   

				try {     
		  
					cmdOne.Transaction = tran;     
					cmdTwo.Transaction = tran;     

					cmdOne.ExecuteNonQuery ();     
					cmdTwo.ExecuteNonQuery ();     

					tran.Commit ();   
				} catch {     
					tran.Rollback ();   
					IsHit = true;
				}  
			}
		}

		public void WithUsing ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmdOne = cn.CreateCommand ();
				cmdOne.CommandText = "delete from MyTable";
				cmdOne.Connection = cn;
				cmdOne.CommandType = CommandType.StoredProcedure;     


				var cmdTwo = cn.CreateCommand ();
				cmdTwo.CommandText = "delete from NonExisantTanble";
				cmdTwo.Connection = cn;
				cmdTwo.CommandType = CommandType.StoredProcedure;  

				using (var tran = cn.BeginTransaction ()) {					   

					cmdOne.Transaction = tran;     
					cmdTwo.Transaction = tran;     

					cmdOne.ExecuteNonQuery ();     
					cmdTwo.ExecuteNonQuery ();     

					tran.Commit ();
					IsHit = true;
				}
			}
		}

		public void IsolationLevelExample ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmdOne = cn.CreateCommand ();
				cmdOne.CommandText = "spUpdateFoo";
				cmdOne.Connection = cn;
				cmdOne.CommandType = CommandType.StoredProcedure;     


				var cmdTwo = cn.CreateCommand ();
				cmdTwo.CommandText = "spUpdateMoo";
				cmdTwo.Connection = cn;
				cmdTwo.CommandType = CommandType.StoredProcedure;  

				using (var tran = cn.BeginTransaction (IsolationLevel.ReadCommitted)) {					   

					cmdOne.Transaction = tran;     
					cmdTwo.Transaction = tran;     
					IsolationLevel isolationLevel = tran.IsolationLevel;		

					cmdOne.ExecuteNonQuery ();     
					cmdTwo.ExecuteNonQuery ();     

					tran.Commit ();
				}
			}
		}

		public void CheckPointExample ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     

				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmdOne = cn.CreateCommand ();
				cmdOne.CommandText = "spUpdateFoo";
				cmdOne.Connection = cn;
				cmdOne.CommandType = CommandType.StoredProcedure;

				var cmdTwo = cn.CreateCommand ();
				cmdTwo.CommandText = "spUpdateMoo";
				cmdTwo.Connection = cn;
				cmdTwo.CommandType = CommandType.StoredProcedure;  

				using (var tran = cn.BeginTransaction (IsolationLevel.ReadCommitted)) {			   

					cmdOne.Transaction = tran;     
					cmdTwo.Transaction = tran;     

					cmdOne.ExecuteNonQuery ();  

					// MySQL Connect providers does not support save points.
					//tran.Save ("Charlie");	   
					cmdTwo.ExecuteNonQuery ();     

					//tran.Rollback ("Charlie");
					tran.Commit ();
				}
			}
		}

		public void NestedTransactionExample ()
		{
			var connectionDetails = 
				ConfigurationManager.ConnectionStrings ["MyDatabase"];

			var providerName = connectionDetails.ProviderName;
			var connectionString = connectionDetails.ConnectionString;

			var dbFactory = DbProviderFactories.GetFactory (providerName);

			using (var cn = dbFactory.CreateConnection ()) {     
				cn.ConnectionString = connectionString;     
				cn.Open (); 

				var cmdOne = cn.CreateCommand ();
				cmdOne.CommandText = "delete from MyTable";
				cmdOne.Connection = cn;
				cmdOne.CommandType = CommandType.StoredProcedure;     


				var cmdTwo = cn.CreateCommand ();
				cmdTwo.CommandText = "delete from NonExisantTanble";
				cmdTwo.Connection = cn;
				cmdTwo.CommandType = CommandType.StoredProcedure;  

				using (var tranOuter = cn.BeginTransaction ()) {					   

					cmdOne.Transaction = tranOuter;     
					cmdOne.ExecuteNonQuery ();  

					using (var tranInner = cn.BeginTransaction ()) {	
						cmdTwo.Transaction = tranInner;

						cmdTwo.ExecuteNonQuery ();     
						tranInner.Rollback ();
					}		

					tranOuter.Commit ();
				}
			}
		}
	}
}