using System;

namespace le0zh.Infrastructure.Data.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
