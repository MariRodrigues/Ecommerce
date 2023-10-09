using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork BeginTransaction();
        Task CommitAsync();
        void Commit();
        void RollbackTransaction();

    }
}
