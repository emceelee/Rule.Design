using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core
{
    //Default implementation 1
    //Generic rule that acts on object of type T, producing RuleResult<TResult>
    public class Rule<T, TResult> : IRule<T, TResult>
    {
        private Func<T, RuleResult<TResult>> _func;

        public Rule() { }

        public Rule(Func<T, RuleResult<TResult>> func)
        {
            _func = func;
        }

        public IRuleResult<TResult> Execute(T obj)
        {
            return _func?.Invoke(obj);
        }
    }
}
