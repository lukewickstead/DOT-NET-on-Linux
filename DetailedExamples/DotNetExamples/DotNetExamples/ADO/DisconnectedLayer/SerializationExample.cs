using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ADO.DisconnectedLayer
{
	public class SerializationExample
	{
		public DataSet PreDataSet { get; private set; }
		public DataSet PostDataSet { get; private set; }

		public SerializationExample ()
		{
			string afileName = Path.GetTempFileName ();

			var reader = new DataTableReaderExample ();
			PreDataSet = reader.DS;

			PreDataSet.RemotingFormat = SerializationFormat.Binary;   

			using (var fs = new FileStream (afileName, FileMode.Create)) { 
				var bf = new BinaryFormatter ();   
				bf.Serialize (fs, PreDataSet);   
			}			

			using (Stream fs = File.OpenRead (afileName)) {     
				var bf = new BinaryFormatter ();   
				PostDataSet = (DataSet)bf.Deserialize (fs);    
			}
		}
	}
}

