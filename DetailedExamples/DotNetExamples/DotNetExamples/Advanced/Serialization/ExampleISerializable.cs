using System;
using System.Runtime.Serialization;

namespace Advanced.Serialization
{
	[Serializable] 
	public class ExampleISerializable : ISerializable
	{
		public ExampleISerializable ()
		{
		}

		public string MyField { get; set; }

		protected ExampleISerializable (SerializationInfo info, StreamingContext ctx)
		{   
			MyField = (string)info.GetValue ("MyField", typeof(string));
		}

		public void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			info.AddValue ("MyField", MyField, typeof(string)); 
		}
	}
}