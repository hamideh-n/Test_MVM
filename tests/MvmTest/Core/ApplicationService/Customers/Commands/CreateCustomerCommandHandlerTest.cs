

using Moq;
using Mvm.Core.ApplicationServices.Customers.Commands;
using Mvm.Core.ApplicationServices.Customers.Queries;
using Mvm.Core.Domain.Customers.Commands;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Queries;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Core.Domain.UnitOfWork;
using Mvm.Framework.Commands;
using MvmTest.Core.ApplicationService.Customers.Mocks;
using Shouldly;

namespace MvmTest.Core.ApplicationService.Customers.Commands
{
    
    public class CreateCustomerCommandHandlerTest
    {

        private readonly Mock<ICustomerQueryRepository> _mockCustomerQueryGetAllRepository;
        public  Mock<ICustomerQueryRepository> _mockCustomerQueryIsUnicInformationRepository;
        private readonly Mock<ICustomerCommandRepository> _mockCustomerRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        

        public CreateCustomerCommandHandlerTest()
        {
            _mockCustomerRepository = RepositoryMocks.AddAsync();
            _mockCustomerQueryGetAllRepository = RepositoryMocks.GetAll();
            _mockUnitOfWork = UnitOfWorkMock.GetSaveAsync();
            
        }

        [Fact]
        public async Task Handle_AddCustomerUnicInformation_IssuccessIsTrue()
        {
            //
            
            var handler = new CreateCustomerCommandHandler(_mockUnitOfWork.Object, _mockCustomerRepository.Object, _mockCustomerQueryGetAllRepository.Object);
            //Assert
            var command=new CreateCustomerCommand(){Firstname= "sara",Lastname="salimi",DateOfBirth= DateTime.Now,Email= "sara.salimi@yahoo.com",BankAccountNumber = "0101416297007",PhoneNumber = "09144261258" };
            //
            var result = await handler.Handle(command);
            result.ShouldBeOfType<CommandResult>();
            result.Errors.Count().ShouldBe(0);
            result.Errors.ShouldBeEmpty();
            result.IsSuccess.ShouldBe(true);
        }

        [Fact]
        public async Task Handle_AddCustomerUnicInformation_IssuccessIsFalse()
        {
            //
            var handler = new CreateCustomerCommandHandler(_mockUnitOfWork.Object, _mockCustomerRepository.Object, _mockCustomerQueryGetAllRepository.Object);
            _mockCustomerQueryIsUnicInformationRepository = RepositoryMocks.IsUnicInformation();

            //Assert
            
            var command = new CreateCustomerCommand() { Firstname = "hamideh", Lastname = "naseri", DateOfBirth = new DateTime(2012, 09, 01), Email = "naseri.kobra@yahoo.com", BankAccountNumber = "0101416297007", PhoneNumber = "09124261258" };
            //
            var result = await handler.Handle(command);
            result.ShouldBeOfType<CommandResult>();
            result.Errors.Count().ShouldBe(1);
            result.IsSuccess.ShouldBe(false);
           
        }
    }
}
