
using Microsoft.EntityFrameworkCore;
using Mvm.Core.Domain.Customers;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;

namespace Mvm.Infrastructures.Data.SqlServer.Customers.Repositories
{
    public class CustomerQueryRepository:ICustomerQueryRepository
    {
        private readonly MvmDbContext _dbContext;

        public CustomerQueryRepository(MvmDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAllAsync()
        {
            var query = await _dbContext.Customers.Where(c=>c.Deleted==false).AsNoTracking().ToListAsync();
            return query;
        }


        public async Task<Customer> IsUnicInformationAsync(string firstName, string lastName, DateTime dateOfBirth)
        {
            return await _dbContext.Customers.Where(c =>
                c.Firstname == firstName && c.Lastname == lastName &&
                c.DateOfBirth == dateOfBirth).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<Customer> IsUnicEmailAsync(string email)
        {
            return await _dbContext.Customers.Where(c => c.Email == email
            ).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var query = await _dbContext.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
            return query ;
        }

    }

   

   
}
