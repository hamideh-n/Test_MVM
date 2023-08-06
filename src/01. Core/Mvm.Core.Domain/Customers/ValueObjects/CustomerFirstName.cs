using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvm.Core.Domain.Customers.Exeptions;

namespace Mvm.Core.Domain.Customers.ValueObjects
{
    public class CustomerFirstName
    {
        public string Value { get; }
        public CustomerFirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new CustomerFirstNameException();
            }

            value = value.Trim();


        }


        public static implicit operator string(CustomerFirstName name) => name.Value;

        public static implicit operator CustomerFirstName(string name) => new(name);

    }
}
