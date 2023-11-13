using Ecommerce.Domain;
using Ecommerce.Infra.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(UserDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return this;
        }

        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Dispose();
                    GC.SuppressFinalize(this);
                }
                catch
                {
                }
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }
    }
}
