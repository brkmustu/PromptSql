using System.Collections.Generic;
using System.Data;

namespace PromptSql
{
    public interface ISqlMapper<TResult>
    {
        IEnumerable<TResult> Map();
        ISqlMapper<TResult> SetData(DataTable dataTable);
    }
}