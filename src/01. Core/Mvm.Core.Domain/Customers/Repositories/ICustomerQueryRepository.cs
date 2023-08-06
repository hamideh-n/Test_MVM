
using Mvm.Core.Domain.Customers.Entities;

namespace Mvm.Core.Domain.Customers.Repositories
{
    public interface ICustomerQueryRepository
    {


        //Task<CustomerSingleton> GetByIdSingletonAsync(int id);
        Task<List<Customer>> GetAllAsync();

         Task<Customer> GetByIdAsync(int id);

         
         Task<Customer> IsUnicInformationAsync(string firstName,string lastName, DateTime dateOfBirth);

         Task<Customer> IsUnicEmailAsync(string email);


    }
}
