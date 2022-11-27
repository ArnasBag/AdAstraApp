using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.Exceptions
{
    public class CascadeDeleteRestrictedException : Exception
    {
        public CascadeDeleteRestrictedException(string message) : base(message)
        {

        }
    }
}
