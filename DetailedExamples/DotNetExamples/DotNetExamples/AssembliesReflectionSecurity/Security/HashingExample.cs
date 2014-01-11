using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;

namespace AssembliesReflectionSecurity.Security
{
	public class ToHash
	{
		public string FieldString { get; set; }

		public int FieldInt { get; set; }

		public bool FieldBool { get; set; }

		public decimal FieldDecimal { get; set; }

		public override int GetHashCode ()
		{
			return string.Format ("{0}-{1}-{2}-{3}", FieldString, FieldInt, FieldBool, FieldDecimal).GetHashCode ();
		}
	}
}