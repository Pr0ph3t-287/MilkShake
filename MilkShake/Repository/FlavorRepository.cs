using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class FlavorRepository(IUnitOfWork unitOfWork) : RepositoryBase<Flavor>(unitOfWork)
    {

    }
}
