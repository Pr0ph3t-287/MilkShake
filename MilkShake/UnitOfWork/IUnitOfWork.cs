using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MilkShake.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
