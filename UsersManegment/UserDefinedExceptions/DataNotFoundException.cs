using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersManegment.UserDefinedExceptions
{
    class DataNotFoundException : SystemException
    {
        public DataNotFoundException(string msg) : base(msg)
        { 
        
        }
    }
}
