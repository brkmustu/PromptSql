using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptSql.Tests.TestModels
{
    public class TestModule : SqlToolsModule
    {
        public override string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["TestSqlConnection"];
        }
    }
}
