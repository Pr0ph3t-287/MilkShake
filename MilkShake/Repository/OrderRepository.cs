using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class OrderRepository(IUnitOfWork unitOfWork) : RepositoryBase<Order>(unitOfWork)
    {
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderByUserId(int userId)
        {
            return Ok(await dbSet.Where(u => u.UserId == userId).ToListAsync());
        }
    }
}
