using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule.Core.Interface
{
    //Defines the interface for a generic Rule to execute on type T, which when executed, returns an IRuleResult of type TResult
    public interface IRule<T, TResult>
    {
        IRuleResult<TResult> Execute(T obj);
    }
}
