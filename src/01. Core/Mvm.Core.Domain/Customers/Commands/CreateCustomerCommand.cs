﻿

using Mvm.Framework.Commands;

namespace Mvm.Core.Domain.Customers.Commands
{

    public class CreateCustomerCommand : ICommand
    {
        public string Firstname { get;  set; }
        public string Lastname { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Email { get;  set; }
        public string BankAccountNumber { get;  set; }
    }
}