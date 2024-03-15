using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class UserRepository(IUnitOfWork unitOfWork) : RepositoryBase<User>(unitOfWork)
    {

    }
}
