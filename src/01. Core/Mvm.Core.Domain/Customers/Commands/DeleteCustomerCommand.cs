

using Mvm.Framework.Commands;

namespace Mvm.Core.Domain.Customers.Commands
{
    public class DeleteCustomerCommand:ICommand
    {
        public int Id { get; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }

      
    }
}
