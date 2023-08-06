
using Moq;
using Mvm.Core.ApplicationServices.Customers.Queries;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Queries;
using Mvm.Core.Domain.Customers.Repositories;
using MvmTest.Core.ApplicationService.Customers.Mocks;
using Shouldly;

namespace MvmTest.Core.ApplicationService.Customers.Queries
{
    public class GetAllCustomerQueryHandlerTest
    {
        private readonly Mock<ICustomerQueryRepository> _mockCustomerRepository;
        public GetAllCustomerQueryHandlerTest()
        {
            _mockCustomerRepository = RepositoryMocks.GetAll();
        }

        [Fact]
        public async Task TestGetAllCustomer()
        {
            var handler = new GetAllCustomerQueryHandler(_mockCustomerRepository.Object);
            var result = await handler.Handle(new GetAllCustomerQuery());
            result.ShouldBeOfType<List<Customer>>();
            result.Count.ShouldBe(4);
        }



    }
}
