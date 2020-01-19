using System;

namespace SqlTools
{
    public interface ISqlOperations
    {
        SqlOptions BeginOperation(Func<BeginOperation, SqlOptions> option);
    }
}