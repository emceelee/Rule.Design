using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rule.Core.Interface;

namespace Rule.Core
{
    public class RuleResult<T> : IRuleResult<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
    }
}
