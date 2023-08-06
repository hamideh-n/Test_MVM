using Mvm.Core.Domain.Customers.Commands;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Core.Domain.UnitOfWork;
using Mvm.Framework.Commands;
namespace Mvm.Core.ApplicationServices.Customers.Commands
{
    public class CreateCustomerCommandHandler:CommandHandler<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerCommandRepository _commandRepository;
        private readonly ICustomerQueryRepository _queryRepository;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerCommandRepository commandRepository, ICustomerQueryRepository queryRepository) : base()
        {
            _unitOfWork = unitOfWork;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public override async Task<CommandResult> Handle(CreateCustomerCommand command)
        {
            var customer = new Customer(command.Firstname, command.Lastname, command.DateOfBirth, command.PhoneNumber,
                command.Email, command.BankAccountNumber);
            if (await IsValid(command))
            {
               await _commandRepository.AddAsync(customer);
               var result = await _unitOfWork.SaveAsync();
                return Ok();
            }
          
            return Failure();
        }

        private async Task<bool>  IsValid(CreateCustomerCommand command)
        {
         
            bool isValid = true;
            var customerInfo = await _queryRepository.IsUnicInformationAsync(command.Firstname, command.Lastname, command.DateOfBirth);
            if (customerInfo!=null)
            {
                AddError("اطلاعات شما وجود دارد ");
                isValid = false;
            }

            var customerEmail = await _queryRepository.IsUnicEmailAsync(command.Email);
            if (customerEmail!=null)
            {
                AddError("ایمیل تکراری است ");
                isValid = false;
            }
            return isValid;
        }
        
    }
}
