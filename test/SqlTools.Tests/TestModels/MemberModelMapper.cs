using System;
using System.Data;

namespace SqlTools.Tests.TestModels
{
    public class MemberModelMapper : SqlMapper<MemberModel>
    {
        protected override MemberModel Map(DataRow source)
        {
            return new MemberModel
            {
                Id = source.Field<int>("Id"),
                FirstName = source.Field<string>("FirstName"),
                LastName = source.Field<string>("LastName"),
                Age = source.Field<int?>("Age"),
                BirthDate = source.Field<DateTime?>("BirthDate"),
                CreateDate = source.Field<DateTime?>("CreateDate")
            };
        }
    }
}
