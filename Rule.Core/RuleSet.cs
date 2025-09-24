using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core
{
    public class RuleSet<T, TResult>
    {
        private RuleRegistry<T, TResult> _registry;
        private List<string> _rules = new List<string>();
        private string _addErrorMessage = "Error adding rule to RuleSet: ";

        public RuleSet(RuleRegistry<T, TResult> registry)
        {
            _registry = registry;
        }

        public RuleRegistry<T, TResult> Registry
        {
            get
            {
                return _registry;
            }
        }

        public void AddRule(string key)
        {
            if (key is null)
            {
                throw new ArgumentNullException($"{_addErrorMessage} key is null. ");
            }
            if (!Registry.ContainsKey(key))
            {
                throw new ArgumentException($"{_addErrorMessage} Rule {key} has not been registered in RuleRegistry. ");
            }
            if(_rules.Contains(key))
            {
                throw new ArgumentException($"{_addErrorMessage} Rule {key} has already been added to RuleSet. ");
            }

            _rules.Add(key);
        }

        public Dictionary<string, IRuleResult<TResult>> Execute(T obj)
        {
            var results = new Dictionary<string, IRuleResult<TResult>>();
            _rules.ForEach(key =>
            {
                IRule<T, TResult> rule = Registry.RetrieveInstance(key);

                results.Add(key, rule.Execute(obj));
            });

            return results;
        }
    }
}
