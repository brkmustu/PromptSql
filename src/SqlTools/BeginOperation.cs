using System.Data.SqlClient;

namespace SqlTools
{
    public class BeginOperation
    {
        private SqlConnection _sqlConnection;

        public BeginOperation(string connectionString)
        {
            this._sqlConnection = new SqlConnection(connectionString);
        }

        public SqlOptions CreateOptions(string commandText)
        {
            return new SqlOptions(sqlConnection: this._sqlConnection, commandText: commandText);
        }
    }
}
