using System;
using System.Collections.Generic;
using SqlTools.Tests.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SqlTools.Tests
{
    [TestClass]
    public class QueryOperationTests : TestBase
    {
        [TestMethod]
        public void RowCountTest()
        {
            int rowCount = 1000;

            string query = $@"SELECT TOP {rowCount} * FROM [SampleDb].[dbo].[Books]";

            var datas = new SqlOperations<TestModule>()
                .BeginOperation(x => x.CreateOptions(query))
                .GetQuery<BookModel, BookModelMapper>()
                .GetData();

            Assert.IsNotNull(datas);
            Assert.AreEqual(rowCount, datas.Count());
        }
    }
}
