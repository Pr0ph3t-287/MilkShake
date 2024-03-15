using Microsoft.EntityFrameworkCore;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.UnitOfWork;
using System;
using System.Configuration;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MilkShake.Services
{
    public class Service
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<User> userRepository;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userRepository = new UserRepository(_unitOfWork);
        }

        public async Task Function()
        {

        }
    }
}