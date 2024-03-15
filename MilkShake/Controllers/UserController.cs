using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<User> userRepository;
        Service service;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userRepository = new UserRepository(_unitOfWork);
            service = new Service(unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await userRepository.Get();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsersById(int id)
        {
            return await userRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User User)
        {
            var users = await userRepository.Create(User);
            return users;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await userRepository.Delete(id);
            return users;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User User)
        {
            var users = await userRepository.Update(id, User);
            return users;
        }
    }
}