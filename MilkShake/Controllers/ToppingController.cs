using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToppingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Topping> toppingRepository;
        Service service;

        public ToppingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            toppingRepository = new ToppingRepository(_unitOfWork);
            service = new Service(unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topping>>> GetToppings()
        {
            var toppings = await toppingRepository.Get();
            return toppings;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Topping>> GetToppingsById(int id)
        {
            return await toppingRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Topping>> CreateTopping(Topping Topping)
        {
            var toppings = await toppingRepository.Create(Topping);
            return toppings;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopping(int id)
        {
            var toppings = await toppingRepository.Delete(id);
            return toppings;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopping(int id, Topping Topping)
        {
            var toppings = await toppingRepository.Update(id, Topping);
            return toppings;
        }
    }
}