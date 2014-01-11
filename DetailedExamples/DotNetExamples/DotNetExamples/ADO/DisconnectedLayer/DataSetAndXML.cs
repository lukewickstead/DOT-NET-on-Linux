using System;
using System.Data;

namespace ADO.DisconnectedLayer
{
	public class DataSetAndXML
	{
		public DataSet StartDataSet { get; private set; }

		public DataSet EndDataSet { get; private set; }

		public DataSetAndXML ()
		{
			EndDataSet = new DataSet ();
			StartDataSet = FillDataSetExample.Example ();
		}

		public void ReadXml (string aFile)
		{
			EndDataSet.ReadXml (aFile, XmlReadMode.IgnoreSchema);
		}

		public void ReadXmlSchema (string aFile)
		{
			EndDataSet.ReadXmlSchema (aFile);
		}

		public void WriteXml (string aFile)
		{
			StartDataSet.WriteXml (aFile, XmlWriteMode.IgnoreSchema);   
		}

		public void WriteXmlSchema (string aFile)
		{
			StartDataSet.WriteXmlSchema (aFile);   
		}
	}
}