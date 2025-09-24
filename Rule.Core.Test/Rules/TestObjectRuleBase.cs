using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public abstract class TestObjectRuleBase : IRule<TestObject, bool>
    {
        public abstract IRuleResult<bool> Execute(TestObject obj);
    }
}
