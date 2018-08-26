using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core
{
    public class RuleSet<T>
    {
        private RuleRegistry<T> _registry;
        private List<string> _rules = new List<string>();
        private string _addErrorMessage = "Error adding rule to RuleSet: ";

        public RuleSet(RuleRegistry<T> registry)
        {
            _registry = registry;
        }

        public RuleRegistry<T> Registry
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

        public Dictionary<string, IRuleResult<T>> Execute()
        {
            return Execute(null);
        }

        public Dictionary<string, IRuleResult<T>> Execute(Action<IRule<T>> setupAction)
        {
            var results = new Dictionary<string, IRuleResult<T>>();
            _rules.ForEach(key =>
            {
                IRule<T> rule = Registry.RetrieveInstance(key);
                //Allow consumers to pass in actions to configure rules post-instantiation pre-execution
                setupAction?.Invoke(rule);

                results.Add(key, rule.Execute());
            });

            return results;
        }
    }
}
