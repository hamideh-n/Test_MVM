using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Mvm.Core.Domain.UnitOfWork;

namespace MvmTest.Core.ApplicationService.Customers.Mocks
{
    public class UnitOfWorkMock
    {
        public UnitOfWorkMock() { }


        public static Mock<IUnitOfWork> GetSaveAsync()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(unit => unit.SaveAsync()).ReturnsAsync(1);
            return unitOfWork;
        }
    }
}
