using System.Data.SqlClient;

namespace PromptSql
{
    public class SqlConnectionStateManager
    {
        SqlConnection _sqlConnection;

        public SqlConnectionStateManager(ref SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        protected void OpenConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
        }

        protected void CloseConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
        }
    }
}
