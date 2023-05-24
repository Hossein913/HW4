using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManegment.UserDefinedExceptions
{
    class DefinedException : SystemException
    {
            public override string Message => $"not found record from data storage!";
    }
}
