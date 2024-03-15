using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class ConsistencyRepository(IUnitOfWork unitOfWork) : RepositoryBase<Consistency>(unitOfWork)
    {

    }
}
