using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.DataAccess.Exceptions
{
    public class EntityMissingInDatabaseException : Exception
    {
        public EntityMissingInDatabaseException(string message) : base(message)
        {
        }
    }
}
