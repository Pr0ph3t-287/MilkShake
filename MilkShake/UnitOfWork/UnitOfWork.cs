using Microsoft.EntityFrameworkCore;
using MilkShake.Data;
using System;

namespace MilkShake.UnitOfWork
{
    public class UnitOfWork(MilkShakeDbContext context) : IUnitOfWork
    {
        private readonly MilkShakeDbContext _context = context;
        private bool _disposed = false;

        public DbContext Context => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
