using System;

namespace PromptSql
{
    public class SqlOperations<TSqlToolsModule> : ISqlOperations
        where TSqlToolsModule : SqlToolsModule, new()
    {
        public SqlOptions BeginOperation(Func<BeginOperation, SqlOptions> option)
        {
            string connectionString = System.Activator.CreateInstance<TSqlToolsModule>().GetConnectionString();
            return option(new BeginOperation(connectionString));
        }
    }
}
