using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SqlTools
{
    public class SqlOptions
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        public SqlOptions(SqlConnection sqlConnection, string commandText)
        {
            _sqlConnection = sqlConnection;
            _sqlCommand = new SqlCommand(commandText, sqlConnection);
        }

        public SqlOptions WithTimeOut(int commandTimeOut)
        {
            _sqlCommand.CommandTimeout = commandTimeOut;
            return this;
        }

        public SqlOptions WithCommandType(CommandType commandType)
        {
            _sqlCommand.CommandType = commandType;
            return this;
        }

        public SqlOptions WithParameters(SqlParameter[] parameterCollection)
        {
            if (parameterCollection != null && parameterCollection.Count() > 0)
                this._sqlCommand.Parameters.AddRange(parameterCollection);
            return this;
        }

        public Command GetCommand()
        {
            return new Command(_sqlConnection, _sqlCommand);
        }

        public Query<TResult> GetQuery<TResult, TMapper>()
            where TMapper : SqlMapper<TResult>
        {
            return new Query<TResult>(_sqlConnection, _sqlCommand, Activator.CreateInstance<TMapper>());
        }
    }
}
