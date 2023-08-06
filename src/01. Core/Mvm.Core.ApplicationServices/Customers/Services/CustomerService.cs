using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;

namespace Mvm.Core.ApplicationServices.Customers.Services
{
    public class CustomerService
    {
        private readonly ICustomerQueryRepository _queryRepository;

        public CustomerService(ICustomerQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }
        public async Task<Customer> IsUnicInformationServiceAsync(string firstname, string lastname, DateTime dateOfBirth)
        {
           return await _queryRepository.IsUnicInformationAsync(firstname, lastname,dateOfBirth);
        }

        public async Task<Customer> IsUnicEmailServiceAsync(string email)
        {
            return await _queryRepository.IsUnicEmailAsync(email);
        }
    }
}
