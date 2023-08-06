using Mvm.Core.Domain.Customers.Queries;
using Mvm.Framework.Queries;
using Mvm.Core.Domain.Customers.Entities;
using Mvm.Core.Domain.Customers.Repositories;

namespace Mvm.Core.ApplicationServices.Customers.Queries
{
    public class GetByIdQueryHandler: IQueryHandler<GetByIdQuery,Customer>
    {
        private readonly ICustomerQueryRepository _customerQuery;

        public GetByIdQueryHandler(ICustomerQueryRepository customerQuery)
        {
            _customerQuery = customerQuery;
        }
        public async Task<Customer> Handle(GetByIdQuery query)
        {
            return  await _customerQuery.GetByIdAsync(query.Id);
        }
    }
}
