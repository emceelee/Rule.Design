using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TestObjectNonNegativeRule : TestObjectRuleBase
    {
        public override IRuleResult<bool> Execute(TestObject obj)
        {
            //Non-negative integer rule
            RuleResult<bool> result = new RuleResult<bool>();
            result.Result = obj.IntegerProperty >= 0;
            result.Message = $"NonNegative? {result.Result}";
            return result;
        }
    }
}
