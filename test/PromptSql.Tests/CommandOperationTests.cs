using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromptSql.Tests
{
    [TestClass]
    public class CommandOperationTests : TestBase
    {
        [TestMethod]
        public void ExecutingRowCountTest()
        {


            string command = @"SELECT TOP 1000 * FROM [SampleDb].[dbo].[Books]";

            var executingRowCount = new SqlOperations<TestModels.TestModule>()
                .BeginOperation(x => x.CreateOptions(command))
                .GetCommand()
                .ExecuteNonQuery();


        }
    }
}
