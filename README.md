# PromptSql
This library was developed to present your basic ado net operations with a simple fluent interface.

### How to use?

##### 1. Create a PromptSqlModule

    public class SqlModule : PromptSqlModule
    {
        public override string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DefaultConnection"];
        }
    }

##### 2. Command usage

            string sqlCommand = @"UPDATE [dbo].[Books] SET [Description] = 'Test Description' WHERE [Id] = 1";

            new SqlOperations<SqlModule>()
                .BeginOperation(x => x.CreateOptions(sqlCommand))
                .GetCommand()
                .ExecuteNonQuery();
                
##### 3. Query usage

In order to make inquiries, you must first have a model where you will host the data and a sqlmapper. 

get the model as below

    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public int? Age { get; set; }
        public DateTime? CreateDate { get; set; }

    }
    
sqlmapper for this model should be as follows

    public class BookMapper : SqlMapper<Book>
    {
        protected override Book Map(DataRow source)
        {
            return new Book
            {
                Id = source.Field<int>("Id"),
                ISBN = source.Field<string>("ISBN"),
                Age = source.Field<int?>("Age"),
                CreateDate = source.Field<DateTime?>("CreateDate"),
                Description = source.Field<string>("Description")
            };
        }
    }
    
now we are ready to query

            var data = new SqlOperations<SqlModule>()
                .BeginOperation(x => x.CreateOptions(query))
                .GetQuery<Book, BookMapper>()
                .FillData()
                .GetData();
                
that's all
