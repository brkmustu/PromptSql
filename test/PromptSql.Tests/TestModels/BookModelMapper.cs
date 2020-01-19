using System;
using System.Data;

namespace PromptSql.Tests.TestModels
{
    public class BookModelMapper : SqlMapper<BookModel>
    {
        protected override BookModel Map(DataRow source)
        {
            return new BookModel
            {
                Id = source.Field<int>("Id"),
                ISBN = source.Field<string>("ISBN"),
                Description = source.Field<string>("Description"),
                CreateDate = source.Field<DateTime>("CreateDate")
            };
        }
    }
}
