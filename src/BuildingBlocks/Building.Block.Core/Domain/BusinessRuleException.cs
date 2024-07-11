using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Blocks.Core.Domain
{
    public class BusinessRuleException : System.Exception
    {
        public BusinessRuleException(string message) : base(message)
        {

        }
    }
}
