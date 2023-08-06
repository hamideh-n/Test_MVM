using Mvm.Core.Domain.Customers.Commands;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Core.Domain.Customers.ValueObjects;
using Mvm.Core.Domain.UnitOfWork;
using Mvm.Framework.Commands;


namespace Mvm.Core.ApplicationServices.Customers.Commands
{
    public class EditCustomerCommandHandler: CommandHandler<EditCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerQueryRepository _queryRepository;


        public EditCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerQueryRepository queryRepository) : base()
        {
            _unitOfWork = unitOfWork;
            _queryRepository = queryRepository;
        }

        public override async Task< CommandResult> Handle(EditCustomerCommand command)
        {
            var customer= await _queryRepository.GetByIdAsync(command.Id);
            if (await IsValid(command))
            {
               customer.Update(command.Firstname,command.Lastname,command.DateOfBirth,command.PhoneNumber,command.Email,command.BankAccountNumber);
               await _unitOfWork.SaveAsync();
                return Ok();
              
            }
            return Failure();
        }



        private async Task<bool> IsValid(EditCustomerCommand command)
        {
            bool isValid = true;
            var customerInfo = await _queryRepository.IsUnicInformationAsync(command.Firstname,command.Lastname,command.DateOfBirth);
            if (customerInfo != null && customerInfo.Id!= command.Id)
            {
                AddError("اطلاعات شما وجود دارد ");
                isValid = false;
            }
            

            var customerEmail = await _queryRepository.IsUnicEmailAsync(command.Email);
            if (customerEmail != null && customerEmail.Id != command.Id)
            {
                AddError("ایمیل تکراری است ");
                isValid = false;
            }
            return isValid;
        }
    }
}
