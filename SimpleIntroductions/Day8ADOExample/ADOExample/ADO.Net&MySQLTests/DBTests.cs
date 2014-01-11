using ADODotNetAndMySQL.DAL.Models;
using ADODotNetAndMySQL.DAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADODotNetAndMySQLTests
{
	public class DBTests
	{
		// Data Set Up
		public static List<SampleTable> getModels ()
		{
			return new List<SampleTable> () {
				new SampleTable () {
					Name = "Andrey Brown",
					Height = 180,
					DateOfBirth = DateTime.Today.AddYears (-50)
				},
				new SampleTable () {
					Name = "Carl Downing",
					Height = 190,
					DateOfBirth = DateTime.Today.AddYears (-40)
				},
				new SampleTable () {
					Name = "Elgar Frederick",
					Height = 200,
					DateOfBirth = DateTime.Today.AddYears (-30)
				},
				new SampleTable () {
					Name = "Georgye Hargreaves",
					Height = 210,
					DateOfBirth = DateTime.Today.AddYears (-20)
				},
				new SampleTable () {
					Name = "Ian James",
					Height = 220,
					DateOfBirth = DateTime.Today.AddYears (-10)
				}
			};
		}

		public static void TestCanCount ()
		{
			var repository = new ModelRepository ();

			repository.DeleteAll ();			
			repository.Insert (getModels ());

			var count = repository.CountAll ();

			Assert.True (count == getModels ().Count (), "Incorrect count");
		}

		public static void TestCanDelete ()
		{
			var repository = new ModelRepository ();

			repository.Insert (getModels ());

			var models = repository.GetAll ();

			var list = new List<long> () { models.First ().Id };

			repository.Delete (list);	

			var postCount = repository.CountAll ();
			var reRead = repository.Get (list);


			Assert.True (postCount == models.Count () - 1, "Post delete count is incorrect");
			Assert.True (reRead.Count () == 0, "Could retrieve the model after deletion");
		}
	
		public static void TestCanDeleteAll ()
		{
			var repository = new ModelRepository ();

			repository.Insert (getModels ());
		
			var preCount = repository.CountAll ();

			repository.DeleteAll ();	

			var postCount = repository.CountAll ();

			Assert.True (preCount > 0, "No records were available to delete");
			Assert.True (postCount == 0, "Failed to delete all records");
		}

		public static void TestCanInsert ()
		{
			var repository = new ModelRepository ();
			var preModels = getModels ();

			repository.Insert (preModels);

			var postModels = repository.GetAll ();

			var orderdPreModels = preModels.OrderBy (m => m.Name).ThenBy (m => m.DateOfBirth).ThenBy (m => m.Height);
			var orderedPostModels = postModels.OrderBy (m => m.Name).ThenBy (m => m.DateOfBirth).ThenBy (m => m.Height);

			Assert.IsTrue (orderdPreModels.Count () == orderedPostModels.Count ());

			// TODO: better equality comparison 
			Assert.IsTrue (orderdPreModels.ElementAt (0).Name.Equals (orderedPostModels.ElementAt (0).Name));
		}
	
		public static void TestCanUpdate ()
		{
			var repository = new ModelRepository ();

			repository.Insert (getModels ());

			var model = repository.GetAll ().First ();

			model.Name = "Updated Model";

			repository.Update (model);

			var updateModel = repository.Get (new List<long> (){model.Id}).First ();

			Assert.IsTrue (model.Name == updateModel.Name, "Bugger");		
		}
	}
}