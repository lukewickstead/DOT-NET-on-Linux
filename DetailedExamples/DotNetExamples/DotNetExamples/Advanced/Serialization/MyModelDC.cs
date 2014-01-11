using System.Runtime.Serialization;

namespace Advanced.Serialization
{
	[DataContract] public class MyModelDC
	{
		[DataMember]     
		public int AnInt { get; set; }

		[DataMember]     
		public string AString { get; set; }

		[DataMember]     
		public bool ABool { get; set; }

		public override bool Equals (object obj)
		{
			var otherModel = (MyModelDC)obj;

			return ABool.Equals (otherModel.ABool) &&
			AnInt.Equals (otherModel.AnInt) &&
			AString.Equals (otherModel.AString);
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}
	}
}