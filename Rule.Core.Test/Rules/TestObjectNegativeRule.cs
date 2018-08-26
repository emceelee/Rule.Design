﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TestObjectNegativeRule : TestObjectRuleBase
    {
        public override IRuleResult<bool> Execute()
        {
            //Non-negative integer rule
            RuleResult<bool> result = new RuleResult<bool>();
            result.Result = ObjectInstance.IntegerProperty < 0;
            result.Message = $"Negative? {result.Result}";
            return result;
        }
    }
}
