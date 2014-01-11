using System;

namespace Advanced.Serialization
{
	[Serializable] 
	public class MyModel
	{
		public int AnInt { get; set; }

		public string AString { get; set; }

		public bool ABool { get; set; }

		[NonSerialized]     
		public string NonSerializedField;

		public override bool Equals (object obj)
		{
			var otherModel = (MyModel)obj;

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