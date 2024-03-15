using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class OrderRepository(IUnitOfWork unitOfWork) : RepositoryBase<Order>(unitOfWork)
    {

    }
}
