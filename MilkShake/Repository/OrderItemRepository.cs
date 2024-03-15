using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class OrderItemRepository(IUnitOfWork unitOfWork) : RepositoryBase<OrderItem>(unitOfWork)
    {

    }
}
