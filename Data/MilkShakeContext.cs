using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkShake.Models;

namespace MilkShake.Data
{
    public class MilkShakeContext : DbContext
    {
        public MilkShakeContext (DbContextOptions<MilkShakeContext> options)
            : base(options)
        {
        }

        public DbSet<MilkShake.Models.User> User { get; set; } = default!;
    }
}
