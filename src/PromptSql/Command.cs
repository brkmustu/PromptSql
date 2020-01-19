using System.Data.SqlClient;

namespace PromptSql
{
    /// <summary>
    /// sql command operations
    /// </summary>
    public class Command : SqlConnectionStateManager
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        public Command(SqlConnection sqlConnection, SqlCommand sqlCommand)
            : base(ref sqlConnection)
        {
            _sqlConnection = sqlConnection;
            _sqlCommand = sqlCommand;
        }

        public int ExecuteNonQuery()
        {
            OpenConnection();

            this._sqlCommand.ExecuteNonQuery();

            int executinRowCount = this._sqlCommand.ExecuteNonQuery();

            CloseConnection();

            return executinRowCount;
        }
    }
}
