using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TestObjectOddRule : TestObjectRuleBase
    {
        public override IRuleResult<bool> Execute()
        {
            //Odd integer
            RuleResult<bool> result = new RuleResult<bool>();
            result.Result = ObjectInstance.IntegerProperty % 2 != 0;
            result.Message = $"Odd? {result.Result}";
            return result;
        }
    }
}
