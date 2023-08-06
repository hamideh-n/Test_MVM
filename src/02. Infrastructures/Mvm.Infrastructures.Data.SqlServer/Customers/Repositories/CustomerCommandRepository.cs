
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;

namespace Mvm.Infrastructures.Data.SqlServer.Customers.Repositories
{
    public class CustomerCommandRepository: ICustomerCommandRepository
    {
        private readonly MvmDbContext _dbContext;

        public CustomerCommandRepository(MvmDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public async Task AddAsync(Customer customer)
        {
           await _dbContext.Customers.AddAsync(customer);
        }

    }
}
