using NUnit.Framework;
using System;
using System.IO;
using ADO.DisconnectedLayer;

namespace ADO.DisconnectedLayer.Tests
{
	[TestFixture ()]
	public class DataSetAndXMLTests
	{
		[Test ()]
		public void TestXML ()
		{
			var sut = new DataSetAndXML ();
			var xmlFileName = Path.GetTempFileName ();
			var xsdFileName = Path.GetTempFileName ();

			sut.WriteXml (xmlFileName );
			sut.WriteXmlSchema (xsdFileName);
			sut.ReadXmlSchema (xsdFileName);
			sut.ReadXml (xmlFileName);

			Assert.AreEqual (sut.StartDataSet.Tables.Count, sut.EndDataSet.Tables.Count);
			Assert.AreEqual (sut.StartDataSet.Tables[0].Columns.Count, sut.EndDataSet.Tables[0].Columns.Count);
			Assert.AreEqual (sut.StartDataSet.Tables[0].Rows.Count, sut.EndDataSet.Tables[0].Rows.Count);
		}

		[Test ()]
		public void TestSchema ()
		{
			var sut = new DataSetAndXML ();
			var xsdFileName = Path.GetTempFileName ();

			sut.WriteXmlSchema (xsdFileName);
			sut.ReadXmlSchema (xsdFileName);

			Assert.AreEqual (sut.StartDataSet.Tables.Count, sut.EndDataSet.Tables.Count);
			Assert.AreEqual (sut.StartDataSet.Tables[0].Columns.Count, sut.EndDataSet.Tables[0].Columns.Count);
		}
	}
}