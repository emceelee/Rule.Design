using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule.Core.Interface
{
    public interface IRule<T>
    {
        IRuleResult<T> Execute();
    }
}
