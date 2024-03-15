using Microsoft.EntityFrameworkCore;
using MilkShake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilkShake.Data
{
    public class MilkShakeDbContext(DbContextOptions<MilkShakeDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = default!;
    }
}
