using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace PromptSql
{
    public abstract class SqlMapper<TResult> : ISqlMapper<TResult>
    {
        private DataTable _dataTable;

        public double Performance { get; set; }

        public ISqlMapper<TResult> SetData(DataTable dataTable)
        {
            this._dataTable = dataTable;
            return this;
        }

        public IEnumerable<TResult> Map()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = new List<TResult>();

            foreach (DataRow item in _dataTable.Rows) result.Add(Map(item));

            stopwatch.Stop();

            this.Performance = stopwatch.Elapsed.TotalSeconds;

            return result;
        }

        protected abstract TResult Map(DataRow source);

        public SqlMapper()
        {
            this.Performance = 0;
        }
    }
}
