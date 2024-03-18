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
        UserService service;
        private readonly UserRepository _userRepository;

        public UserController(IUnitOfWork unitOfWork, UserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            userRepository = new UserRepository(_unitOfWork);
            service = new UserService(unitOfWork, userRepository);
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.Get();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsersById(int id)
        {
            return await _userRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User User)
        {
            var users = await _userRepository.Create(User);
            return users;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await _userRepository.Delete(id);
            return users;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User User)
        {
            var users = await _userRepository.Update(id, User);
            return users;
        }



        //[HttpPost("login")]
        //public async Task<ActionResult<User>> Login(string email, string password)
        //{
        //    var loggedIn = await service.Login(email, password);
        //    return Ok(loggedIn);
        //}

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginRequestModel loginRequest)
        {
            if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest("Invalid login request.");
            }

            var loggedIn = await service.Login(loginRequest.Email, loginRequest.Password);
            if (loggedIn == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(loggedIn);
        }
    }
}