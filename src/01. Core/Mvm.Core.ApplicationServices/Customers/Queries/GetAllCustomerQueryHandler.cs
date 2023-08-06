using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Queries;
using Mvm.Core.Domain.Customers.Repositories;
using Mvm.Framework.Queries;

namespace Mvm.Core.ApplicationServices.Customers.Queries
{
    public class GetAllCustomerQueryHandler:IQueryHandler<GetAllCustomerQuery,List<Customer>>
    {
        private readonly ICustomerQueryRepository _customerQuery;

        public GetAllCustomerQueryHandler(ICustomerQueryRepository customerQuery)
        {
            _customerQuery = customerQuery;
        }
        public async Task<List<Customer>> Handle(GetAllCustomerQuery query)
        {
           return await _customerQuery.GetAllAsync();
        }
    }
}
