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

        public void OpenConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
        }
    }
}
