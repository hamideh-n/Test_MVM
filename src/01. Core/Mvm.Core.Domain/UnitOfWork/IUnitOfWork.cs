

namespace Mvm.Core.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
    }
}
