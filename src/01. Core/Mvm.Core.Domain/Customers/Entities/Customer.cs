using Mvm.Framework.Domain;

namespace Mvm.Core.Domain.Customers.Entities
{
    public class Customer:AggregateRoot
    {
        public Customer(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber
            
            )
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
           
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }
        public bool Deleted { get; private set; }

        public void Update(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;

        }

        public void Delete()
        {
            Deleted = true;
        }


    }
}
