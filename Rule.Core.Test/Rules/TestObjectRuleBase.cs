using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core.Test.Rules
{
    public class TestObjectRuleBase : IRule<TestObject, bool>
    {
        public virtual IRuleResult<bool> Execute(TestObject obj)
        {
            return new TrueRule().Execute(obj);
        }
    }
}
