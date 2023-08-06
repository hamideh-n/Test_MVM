
using Mvm.Core.Domain.Customers.Repositories;

namespace Mvm.Core.ApplicationServices.Customers.Services
{
    public class CreateCustomerService
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CreateCustomerService(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }


        //public async Task<bool> IsValid(Customer customer)
        //{
        //    var result = true;
        //    if (!await _customerQueryRepository.IsUnicAsync(customer)) result = false;

        //    return result;
        //}
    }
}
