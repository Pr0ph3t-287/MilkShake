using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class UserRepository(IUnitOfWork unitOfWork) : RepositoryBase<User>(unitOfWork)
    {
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            return Ok(await dbSet.FirstOrDefaultAsync(u => u.Email == email));
        }
    }
}
