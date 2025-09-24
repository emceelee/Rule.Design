using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule.Core.Interface
{
    //Defines the interface for a generic Rule Result, which includes a Result of Type TResult and string Message
    public interface IRuleResult<TResult>
    {
        TResult Result
        {
            get;
            set;
        }

        string Message
        {
            get;
            set;
        }
    }
}
