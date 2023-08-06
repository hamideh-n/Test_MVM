
using Castle.Core.Resource;
using Moq;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Framework.Commands;

namespace MvmTest.Core.ApplicationService.Customers.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICustomerQueryRepository> GetAll()
        {

            var Customers = new List<Customer>()
            {
                new Customer("hamideh","naseri",DateTime.Now,"09124261258","naseri.kobra@yahoo.com","0101416297007"),

                new Customer("melika","rezaei",DateTime.Now,"09224375636","melika.rezaei@yahoo.com","0101416297007" ),
                new Customer("sara","naseri",DateTime.Now,"09124375636","sara.rezaei@gmail.com","0101416297007"),
                new Customer("sepideh","daneshi",DateTime.Now,"0912755636","sepideh_daneshi@gmail.com","0101416297007" ),
            };
            var mockCustomerQueryRepository = new Mock<ICustomerQueryRepository>();
            mockCustomerQueryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(Customers);
            return mockCustomerQueryRepository;
        }



        public static Mock<ICustomerQueryRepository> IsUnicInformation()
        {
            var customer = new Customer("hamideh", "naseri", new DateTime(2012, 09, 01), "09124261258", "naseri.kobra@yahoo.com",
                "0101416297007");
            var mockCustomerQueryRepository = new Mock<ICustomerQueryRepository>();
            mockCustomerQueryRepository.Setup(repo => repo.IsUnicInformationAsync(It.IsAny<string>(),It.IsAny<string>(), It.IsAny<DateTime>())).ReturnsAsync(customer);
            return mockCustomerQueryRepository;
        }

        public static Mock<ICustomerCommandRepository> AddAsync()
        {
            var mockCustomerCommandRepository = new Mock<ICustomerCommandRepository>();
            mockCustomerCommandRepository.Setup(repo => repo.AddAsync(It.IsAny<Customer>()));

            return mockCustomerCommandRepository;
        }

       }
       
}
