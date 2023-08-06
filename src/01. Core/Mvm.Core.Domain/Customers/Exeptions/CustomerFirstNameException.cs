using Mvm.Framework.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvm.Core.Domain.Customers.Exeptions
{
    public class CustomerFirstNameException: CustomerException
    {
        public CustomerFirstNameException() : base("customer name cannot be empty")
        {
        }
    }
}
