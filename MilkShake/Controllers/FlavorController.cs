using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlavorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Flavor> flavorRepository;
        Service service;

        public FlavorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            flavorRepository = new FlavorRepository(_unitOfWork);
            service = new Service(unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flavor>>> GetFlavors()
        {
            var flavors = await flavorRepository.Get();
            return flavors;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flavor>> GetFlavorsById(int id)
        {
            return await flavorRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Flavor>> CreateFlavor(Flavor Flavor)
        {
            var flavors = await flavorRepository.Create(Flavor);
            return flavors;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlavor(int id)
        {
            var flavors = await flavorRepository.Delete(id);
            return flavors;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlavor(int id, Flavor Flavor)
        {
            var flavors = await flavorRepository.Update(id, Flavor);
            return flavors;
        }
    }
}