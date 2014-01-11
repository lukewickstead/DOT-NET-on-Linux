using System;
using System.Data;
using MySql.Data.MySqlClient;
using ADODotNetAndMySQL.DAL.ADOProviders;

namespace ADODotNetAndMySQL.DAL.Repositories
{
    /// <summary>
    /// Repository to ADO adapter
    /// </summary>
    public abstract class RepositoryADOAdapter
    {
        protected void ExecuteCommand(string sqlCommand)
        {       
            using (IDbConnection connection = GetConnection())
            {
                using (IDbCommand  cmd = connection.CreateCommand())
                {

                    cmd.CommandText = sqlCommand;
                    cmd.CommandType = CommandType.Text;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }       
            }
        }

        protected T ExecuteScalar<T>(string sqlCommand)
        {

            var aValue = string.Empty;
        
            using (IDbConnection connection = GetConnection())
            {

                using (IDbCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = sqlCommand;
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
            
                    aValue = cmd.ExecuteScalar().ToString();

                    connection.Close();
                }       
            }        

            return (T)Convert.ChangeType(aValue, typeof(T));            
        }

        protected DataTable GetDataTable(string sqlCommand, string tableName)
        {

            using (IDbConnection connection = GetConnection())
            {

                using (IDbCommand cmd = connection.CreateCommand())
                {

                    var dataAdapter = GetDataAdapter();
                    var dataSet = new DataSet();

                    cmd.CommandText = sqlCommand;
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(dataSet);

                    return dataSet.Tables [0];
                }   
            }
        }

        private IDbConnection GetConnection()
        {
            return GetProviderFactor().GetConnection();           
        }

        private IDbDataAdapter GetDataAdapter()
        {               
            return GetProviderFactor().GetDataAdapter();
        }

        private string GetDBConnectionString()
        {
            return GetProviderFactor().GetDBConnectionString();
        }

        private IADODataProviderFactory GetProviderFactor()
        {          
            return new ProviderFactory().GetADODataProviderFactory();
        }
    }
}

