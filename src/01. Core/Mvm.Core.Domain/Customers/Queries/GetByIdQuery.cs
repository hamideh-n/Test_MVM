
using Mvm.Framework.Queries;

namespace Mvm.Core.Domain.Customers.Queries
{
    public class GetByIdQuery:IQuery
    {
        public int Id { get; }


        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
