
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WSMobileApp.DataAccessLayer.Resource;

namespace WSMobileApp.DataAccessLayer
{
    public sealed class DataAccess : IDataAccess
    {
        #region Implementation of IWagonStoreDataAccess

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var sqlConnection = GetSqlConnection())
            {
                using (var sqlCommmand = InitializeSqlManager.GetSqlCommand(storedProcedureParams, storedProcedureName, sqlConnection))
                {
                    return sqlCommmand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public object ExecuteScalar(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var sqlConnection = GetSqlConnection())
            {
                using (var sqlCommmand = InitializeSqlManager.GetSqlCommand(storedProcedureParams, storedProcedureName, sqlConnection))
                {
                    return sqlCommmand.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Executes the data reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public IDataReader ExecuteDataReader(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {

            using (var sqlCommmand = InitializeSqlManager.GetSqlCommand(storedProcedureParams, storedProcedureName, GetSqlConnection()))
            {
                return sqlCommmand.ExecuteReader();
            }

        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string storedProcedureName, IEnumerable<KeyValuePair<string, object>> storedProcedureParams = null)
        {
            using (var sqlConnection = GetSqlConnection())
            {
                using (var dataSet = new DataSet())
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(InitializeSqlManager.GetSqlCommand(storedProcedureParams, storedProcedureName, sqlConnection)))
                    {
                        sqlDataAdapter.Fill(dataSet);
                    }
                    return dataSet;
                }
            }
        }

        #endregion

        #region Initializers

        /// <summary>
        /// The _initialize SQL manager
        /// </summary>
        private SqlManager _initializeSqlManager;

        /// <summary>
        /// Gets the initialize SQL manager.
        /// </summary>
        /// <value>
        /// The initialize SQL manager.
        /// </value>
        private SqlManager InitializeSqlManager
        {
            get { return _initializeSqlManager ?? (_initializeSqlManager = new SqlManager()); }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the SQL connection string.
        /// </summary>
        /// <returns></returns>
        private static string GetSqlConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[DataAccessResource.ConnectionString].ConnectionString;
        }

        /// <summary>
        /// Gets the SQL connection.
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetSqlConnection()
        {
            var sqlConnection = new SqlConnection(GetSqlConnectionString());

            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            else
            {
                sqlConnection.Close();
            }

            return sqlConnection;

        }

        #endregion
    }
}
