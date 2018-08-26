using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule.Core.Interface
{
    public interface IRuleResult<T>
    {
        T Result
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
