using System;

using Mvm.Core.Domain.UnitOfWork;

namespace Mvm.Infrastructures.Data.SqlServer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MvmDbContext _mvmDbContext;

        public UnitOfWork(MvmDbContext mvmDbContext)
        {
            _mvmDbContext = mvmDbContext;
        }
        public int Save()
        {
            return _mvmDbContext.SaveChanges();

        }

        public async Task<int> SaveAsync()
        {
            return await _mvmDbContext.SaveChangesAsync();

        }
    }
}
