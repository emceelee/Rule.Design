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
    public class Rule<T, TResult> : IRule<TResult>
    {
        private Func<T, RuleResult<TResult>> _func;
        private T _obj;

        public Rule() { }

        public Rule(Func<T, RuleResult<TResult>> func)
        {
            _func = func;
        }

        public IRuleResult<TResult> Execute()
        {
            return _func?.Invoke(_obj);
        }

        public T Object
        {
            get { return _obj; }
            set { _obj = value; }
        }
    }

    //Default implementation 2
    //Generic rule that produces RuleResult<TResult>
    public class Rule<TResult> : IRule<TResult>
    {
        private Func<RuleResult<TResult>> _func;

        public Rule() { }

        public Rule(Func<RuleResult<TResult>> func)
        {
            _func = func;
        }

        public IRuleResult<TResult> Execute()
        {
            return _func?.Invoke();
        }
    }
}
