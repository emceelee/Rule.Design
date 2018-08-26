using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TrueRule : IRule<bool>
    {
        public IRuleResult<bool> Execute()
        {
            RuleResult<bool> result = new RuleResult<bool>()
            {
                Result = true,
                Message = "Success"
            };
            return result;
        }
    }
}
