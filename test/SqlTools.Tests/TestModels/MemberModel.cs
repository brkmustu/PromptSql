using System;

namespace SqlTools.Tests.TestModels
{
    public class MemberModel
    {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int? Age { get; set; }
		public DateTime? BirthDate { get; set; }
		public DateTime? CreateDate { get; set; }
	}
}
