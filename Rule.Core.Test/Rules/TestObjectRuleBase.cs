using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TestObjectRuleBase : IRule<bool>
    {
        public TestObject ObjectInstance { get; set; }

        public virtual IRuleResult<bool> Execute()
        {
            return new TrueRule().Execute();
        }
    }
}
