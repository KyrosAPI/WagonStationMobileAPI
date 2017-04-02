
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WSMobileApp.DataAccessLayer.Resource;

namespace WSMobileApp.DataAccessLayer
{
    internal sealed class SqlManager
    {
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

        #region Internal Methods

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <returns></returns>
        internal SqlCommand GetSqlCommand(IEnumerable<KeyValuePair<string, object>> storedProcedureParams, string storedProcedureName)
        {
            var sqlCommand = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName,
                Connection = GetSqlConnection()
            };

            if (storedProcedureParams == null)
            {
                return sqlCommand;
            }

            foreach (var storedProcedureParam in storedProcedureParams)
            {
                sqlCommand.Parameters.AddWithValue(storedProcedureParam.Key, storedProcedureParam.Value);
            }

            return sqlCommand;
        }

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <param name="storedProcedureParams">The stored procedure parameters.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="sqlConnection">The SQL connection.</param>
        /// <returns></returns>
        internal SqlCommand GetSqlCommand(IEnumerable<KeyValuePair<string, object>> storedProcedureParams, string storedProcedureName,SqlConnection sqlConnection)
        {
            var sqlCommand = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = storedProcedureName,
                Connection = sqlConnection
            };

            if (storedProcedureParams == null)
            {
                return sqlCommand;
            }

            foreach (var storedProcedureParam in storedProcedureParams)
            {
                sqlCommand.Parameters.AddWithValue(storedProcedureParam.Key, storedProcedureParam.Value);
            }

            return sqlCommand;
        }

        #endregion
    }
}
