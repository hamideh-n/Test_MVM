

using Mvm.Core.Domain.Customers.Entities;

namespace Mvm.Core.Domain.Customers.Repositories
{
    public interface ICustomerCommandRepository
    {

       Task AddAsync(Customer customer);


    }
}
