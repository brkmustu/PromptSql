using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PromptSql.Tests
{
    public class TestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            string initializeTestTableCommand = $@"
DECLARE @TABLE_SHEMA NVARCHAR(100) = 'dbo'
DECLARE @TABLE_NAME NVARCHAR(100) = 'Members'

IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = @TABLE_SHEMA 
                 AND  TABLE_NAME = @TABLE_NAME))
BEGIN

PRINT 'there is a table. so no action'

END
ELSE
BEGIN

DECLARE @Sql NVARCHAR(1000)

SET @Sql = '
CREATE TABLE [SampleDb].['+@TABLE_SHEMA+'].['+@TABLE_NAME+'](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Age] [int] NULL,
	[BirthDate] [datetime] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_'+@TABLE_NAME+'] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
'

EXEC(@Sql)

PRINT 'no table. so the table was created'

END

";

            try
            {
                var executingRowCount = new SqlOperations<TestModels.TestModule>()
                    .BeginOperation(x => x.CreateOptions(initializeTestTableCommand))
                    .GetCommand()
                    .ExecuteNonQuery();

                if (executingRowCount == 0)
                {
                    throw new Exception("An error was received during test base creation.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
