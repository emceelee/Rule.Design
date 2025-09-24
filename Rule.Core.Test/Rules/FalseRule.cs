using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class FalseRule : IRule<TestObject, bool>
    {
        public IRuleResult<bool> Execute(TestObject obj)
        {
            RuleResult<bool> result = new RuleResult<bool>()
            {
                Result = false,
                Message = "Failure"
            };
            return result;
        }
    }
}
