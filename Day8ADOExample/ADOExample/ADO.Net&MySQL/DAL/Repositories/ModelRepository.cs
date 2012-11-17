using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using ADODotNetAndMySQL.DAL.Models;
using ADODotNetAndMySQL.DAL.Schema;
using ADODotNetAndMySQL.DAL.SQL;


namespace ADODotNetAndMySQL.DAL.Repositories
{
	public class ModelRepository : RepositoryBase<SampleTable>
	{
		public ModelRepository() : base(new SQLHelper<SampleTable>(new SampleTableSQLBuilderHelper()))
		{

		}

        protected override IEnumerable<SampleTable> GetModels (DataTable dataTable)
        {
            return dataTable.Rows
                    .Cast<DataRow> ()
                    .Select (row => new SampleTable
                        {                    
                            Id = row.Field<long>(SampleTableSchema.Fields.Id),
                            Name = row.Field<string> (SampleTableSchema.Fields.Name),
                            Height = row.Field<decimal> (SampleTableSchema.Fields.Height),
                            DateOfBirth = DateTime.Parse(Convert.ToString(row[SampleTableSchema.Fields.DateOfBirth]))
                    }
            );
        }
	}
}

