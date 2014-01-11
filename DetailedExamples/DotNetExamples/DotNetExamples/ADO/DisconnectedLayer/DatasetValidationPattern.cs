using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace ADO.DisconnectedLayer
{
	public class DatasetValidationPattern
	{
		private DataSet DS = new DataSet ();

		public DatasetValidationPattern ()
		{
			DS = FillDataSetExample.Example ();
			PutDataIntoError ();
		}

		private void PutDataIntoError ()
		{
			DS.EnforceConstraints = false;

			var dataRow = DS.Tables [0].Rows [0];
			dataRow.BeginEdit ();
			dataRow ["StringField"] = "Changed...";
			dataRow.SetColumnError ("StringField", "Ohhh nooo!!!");
			dataRow.EndEdit ();
		}

		public string Example ()
		{
			var errorResult = new StringBuilder ();

			var dataSetChanged = DS.GetChanges (DataRowState.Modified);

			if (dataSetChanged != null && dataSetChanged.HasErrors) {
				foreach (DataTable dataTable in dataSetChanged.Tables) {
					if (!dataTable.HasErrors) {
						continue;
					}

					foreach (var dataRow in dataTable.GetErrors()) {
						foreach (var dataColumn in dataRow.GetColumnsInError()) {	
							var errorDesc = dataRow.GetColumnError (dataColumn);
							// Implicitly called with aDataSet.RejectChanges: dataRow.ClearErrors();
							errorResult.AppendLine (errorDesc);
						}
					}
				}

				DS.RejectChanges (); 
			} else if (dataSetChanged != null) {
				// Adapter.Update (dataSetChanged); // Update should happen here if we were not expecting errors
				// implicitly called with adapter Update:_dataSet.AcceptChanges(); 
			}

			return errorResult.ToString ();
		}
	}
}