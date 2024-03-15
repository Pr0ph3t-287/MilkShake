using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class ToppingRepository(IUnitOfWork unitOfWork) : RepositoryBase<Topping>(unitOfWork)
    {

    }
}
