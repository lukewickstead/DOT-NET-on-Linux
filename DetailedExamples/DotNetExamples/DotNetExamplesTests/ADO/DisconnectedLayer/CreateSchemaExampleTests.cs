using NUnit.Framework;
using System;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class CreateSchemaExampleTests
	{
		[Test ()]
		public void TestRelations ()
		{
			var sut = new CreateSchemaExample ();

			for (var x = 0; x < 10; x++) {

				var childRows = sut.DS.Tables ["TheParent"].Rows [x].GetChildRows (sut.DS.Relations ["ParentChild"]); 
				Assert.IsNotEmpty (childRows);

				var parentRow = sut.DS.Tables ["TheChild"].Rows [x].GetParentRow (sut.DS.Relations ["ParentChild"]); 
				Assert.IsNotNull (parentRow);
			}

			var preCount = sut.DS.Tables ["TheChild"].Rows.Count;
			sut.DS.Tables ["TheParent"].Rows [5].Delete ();

			Assert.AreEqual (preCount - 1, sut.DS.Tables ["TheChild"].Rows.Count);
		}
	}
}