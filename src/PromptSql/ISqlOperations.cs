using System;

namespace PromptSql
{
    public interface ISqlOperations
    {
        SqlOptions BeginOperation(Func<BeginOperation, SqlOptions> option);
    }
}