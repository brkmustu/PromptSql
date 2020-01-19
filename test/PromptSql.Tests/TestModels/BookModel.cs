using System;

namespace PromptSql.Tests.TestModels
{
    public class BookModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
