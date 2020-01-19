using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTools
{
    /// <summary>
    /// sql command operations
    /// </summary>
    public class Command
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        public Command(SqlConnection sqlConnection, SqlCommand sqlCommand)
        {
            _sqlConnection = sqlConnection;
            _sqlCommand = sqlCommand;
        }

        public int ExecuteNonQuery()
        {
            this._sqlConnection.Open();

            this._sqlCommand.ExecuteNonQuery();

            int executinRowCount = this._sqlCommand.ExecuteNonQuery();

            this._sqlConnection.Close();

            return executinRowCount;
        }
    }
}
