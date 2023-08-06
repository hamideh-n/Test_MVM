using Mvm.Core.Domain.Customers.Entities;

namespace Mvm.Core.Domain.Factories
{
    public interface ICustomerFactory
    {
        Customer Create(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email,
            string bankAccountNumber);


    }
}
