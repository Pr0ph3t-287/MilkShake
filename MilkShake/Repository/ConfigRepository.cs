using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;

namespace MilkShake.Repository
{
    public class ConfigRepository(IUnitOfWork unitOfWork) : RepositoryBase<MilkshakeConfig>(unitOfWork)
    {

    }
}
