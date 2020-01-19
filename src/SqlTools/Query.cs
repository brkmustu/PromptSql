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
    public class Query<T> : SqlConnectionStateManager
    {
        private object _mapperInstance;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private DataSet _dataSet = new DataSet();
        private double _performance;

        public Query(SqlConnection sqlConnection, SqlCommand sqlCommand, object mapperInstance) 
            : base(ref sqlConnection)
        {
            this._sqlConnection = sqlConnection;
            this._sqlCommand = sqlCommand;
            this._mapperInstance = mapperInstance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Query<T> FillData()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            using (SqlDataAdapter adapter = new SqlDataAdapter(this._sqlCommand))
            {
                OpenConnection();

                adapter.Fill(this._dataSet);

                CloseConnection();
            }

            stopwatch.Stop();

            this._performance = stopwatch.Elapsed.TotalSeconds;

            return this;
        }

        /// <summary>
        /// Returns the sql query result
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetData()
        {
            _mapperInstance.GetType()
                .GetMethod("SetData")
                .Invoke(_mapperInstance, new object[] { this._dataSet.Tables[0] });

            var _result = (IEnumerable<T>)_mapperInstance.GetType()
                .GetMethod("Map")
                .Invoke(_mapperInstance, null);

            return _result;
        }

        /// <summary>
        /// Returns the sql query result
        /// </summary>
        /// <typeparam name="TResult">result class type</typeparam>
        /// <typeparam name="TMapper">sql mapper type</typeparam>
        /// <param name="tableIndex">If the sql query returns multiple tables, it is the index information of the query you want to return</param>
        /// <returns></returns>
        public IEnumerable<TResult> GetData<TResult, TMapper>(int tableIndex = 0)
            where TMapper : SqlMapper<TResult>
        {
            var mapperInstance = System.Activator.CreateInstance<TMapper>();

            mapperInstance.GetType()
                .GetMethod("SetData")
                .Invoke(mapperInstance, new object[] { this._dataSet.Tables[tableIndex] });

            var _result = (IEnumerable<TResult>)mapperInstance.GetType()
                .GetMethod("Map")
                .Invoke(mapperInstance, null);

            return _result;
        }
    }
}
