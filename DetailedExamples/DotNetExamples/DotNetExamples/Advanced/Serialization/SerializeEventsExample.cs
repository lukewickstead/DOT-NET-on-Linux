using System;
using System.Runtime.Serialization;

namespace Advanced.Serialization
{
	[Serializable]
	public class SerializeEventsExample
	{
		public bool OnSerializingFire { get; set; }

		public bool OnDeserializedFire { get; set; }

		[OnSerializing]   
		private void OnSerializing (StreamingContext context)
		{     
			OnSerializingFire = true;
		}

		[OnDeserialized]   
		private void OnDeserialized (StreamingContext context)
		{
			OnDeserializedFire = true;
		}
	}
}