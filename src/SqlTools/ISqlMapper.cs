using System.Collections.Generic;
using System.Data;

namespace SqlTools
{
    public interface ISqlMapper<TResult>
    {
        IEnumerable<TResult> Map();
        ISqlMapper<TResult> SetData(DataTable dataTable);
    }
}