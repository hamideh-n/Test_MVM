using Mvm.Core.Domain.Customers.Commands;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Core.Domain.UnitOfWork;
using Mvm.Framework.Commands;


namespace Mvm.Core.ApplicationServices.Customers.Commands
{
    public class DeleteCustomerCommandHandler: CommandHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerQueryRepository _customerQuery;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerQueryRepository customerQuery,IUnitOfWork unitOfWork) : base()
        {
            _customerQuery = customerQuery;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CommandResult> Handle(DeleteCustomerCommand command)
        {
          var customer= await _customerQuery.GetByIdAsync(command.Id);
          if (customer != null)
          {
              customer.Delete();
              var result = await _unitOfWork.SaveAsync();
              return Ok();
            }
         
             return Failure("این مشتری وجود ندارد");
        }
    }
}
