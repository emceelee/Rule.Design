using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core
{
    public class RuleRegistry<T>
    {
        private Dictionary<string, Type> _rules = new Dictionary<string, Type>();
        private Dictionary<string, IRule<T>> _ruleInstances = new Dictionary<string, IRule<T>>();
        private string _registerErrorMessage = "Error registering rule in RuleRegistry: ";

        public void RegisterRule(string key, Type type, bool singleInstance = false)
        {
            //instantiate a single new rule instance to be shared across all executions
            if (singleInstance)
            {
                IRule<T> rule = Activator.CreateInstance(type) as IRule<T>;
                RegisterRule(key, rule);
            }
            else
            {
                RegisterRule(key, type);
            }
        }

        public void RegisterRule(string key, Type type)
        {
            if (key == null)
            {
                throw new ArgumentNullException($"{_registerErrorMessage} key is null. ");
            }
            //RuleRegistry can only register types of IRule
            if (!type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRule<>)))
            {
                throw new ArgumentException(string.Format("{0} type {1} does not implement interface IRule<T>. ", _registerErrorMessage, type.ToString()));
            }
            if (_rules.ContainsKey(key))
            {
                throw new ArgumentException($"{_registerErrorMessage} key {key} already exists. ");
            }

            _rules.Add(key, type);
        }

        public void RegisterRule(string key, IRule<T> instance)
        {
            if (key == null)
            {
                throw new ArgumentNullException($"{_registerErrorMessage} key is null. ");
            }
            if (_rules.ContainsKey(key))
            {
                throw new ArgumentException($"{_registerErrorMessage} key {key} already exists. ");
            }
            if (instance == null)
            {
                throw new ArgumentException($"{_registerErrorMessage} instance is null. ");
            }

            _rules.Add(key, instance.GetType());
            _ruleInstances.Add(key, instance);
        }

        public bool ContainsKey(string key)
        {
            return _rules.ContainsKey(key);
        }

        public bool ContainsRule(Type type)
        {
            return _rules.ContainsValue(type);
        }

        public Type RetrieveRuleType(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException($"{_registerErrorMessage} key is null. ");
            }

            Type type;
            _rules.TryGetValue(key, out type);

            return type;
        }

        public IRule<T> RetrieveInstance(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException($"{_registerErrorMessage} key is null. ");
            }
            
            IRule<T> rule;
            _ruleInstances.TryGetValue(key, out rule);

            if(rule != null)
            {
                return rule;
            }

            Type type = RetrieveRuleType(key);
            
            if(type == null)
            {
                return null;
            }

            rule = Activator.CreateInstance(type) as IRule<T>;

            Debug.Assert(rule != null);

            return rule;
        }
    }
}
