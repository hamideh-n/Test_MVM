using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvm.Core.Domain.Customers.Entities;

namespace Mvm.Core.Domain.Factories
{
    public class CustomerFactory: ICustomerFactory
    {
        public Customer Create(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email,
            string bankAccountNumber) =>
            new Customer(firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);

    }
}
