using System;

namespace PromptSql
{
    public class SqlOperations<TModule> : ISqlOperations
        where TModule : PromptSqlModule, new()
    {
        public SqlOptions BeginOperation(Func<BeginOperation, SqlOptions> option)
        {
            string connectionString = Activator.CreateInstance<TModule>().GetConnectionString();
            return option(new BeginOperation(connectionString));
        }
    }
}
