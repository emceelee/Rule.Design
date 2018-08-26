using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TestObjectEvenRule : TestObjectRuleBase
    {
        public override IRuleResult<bool> Execute()
        {
            //Even integer
            RuleResult<bool> result = new RuleResult<bool>();
            result.Result = ObjectInstance.IntegerProperty % 2 == 0;
            result.Message = $"Even? {result.Result}";
            return result;
        }
    }
}
