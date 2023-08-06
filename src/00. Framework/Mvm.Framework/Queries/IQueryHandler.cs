

namespace Mvm.Framework.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
    {
       Task<TResult> Handle(TQuery query);
    }
}
