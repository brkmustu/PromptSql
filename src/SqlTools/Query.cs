using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace SqlTools
{
    /// <summary>
    /// sql query operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Query<T>
    {
        private object _mapperInstance;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private DataSet _dataSet = new DataSet();
        private double _performance;

        public Query(SqlConnection sqlConnection, SqlCommand sqlCommand, object mapperInstance)
        {
            this._sqlConnection = sqlConnection;
            this._sqlCommand = sqlCommand;
            this._mapperInstance = mapperInstance;
        }

        /// <summary>
        /// Returns the sql query result
        /// </summary>
        /// <param name="tableIndex">If the sql query returns multiple tables, it is the index information of the query you want to return</param>
        /// <returns></returns>
        public IEnumerable<T> GetData(int tableIndex = 0)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            this._sqlConnection.Open();

            using (SqlDataAdapter adapter = new SqlDataAdapter(this._sqlCommand))
            {
                this._sqlConnection.Open();

                adapter.Fill(this._dataSet);

                this._sqlConnection.Close();
            }

            _mapperInstance.GetType()
                .GetMethod("SetData")
                .Invoke(_mapperInstance, new object[] { this._dataSet.Tables[tableIndex] });

            var _result = (IEnumerable<T>)_mapperInstance.GetType()
                .GetMethod("Map")
                .Invoke(_mapperInstance, null);

            stopwatch.Stop();

            this._performance = stopwatch.Elapsed.TotalSeconds;

            return _result;
        }

        public DataSet GetDataSet()
        {
            return this._dataSet;
        }
    }
}
