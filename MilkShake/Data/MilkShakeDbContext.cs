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
        public DbSet<Consistency> Consistencies { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
