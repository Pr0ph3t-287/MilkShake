using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsistencyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Consistency> consistencyRepository;

        public ConsistencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            consistencyRepository = new ConsistencyRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consistency>>> GetConsistencys()
        {
            var consistencys = await consistencyRepository.Get();
            return consistencys;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consistency>> GetConsistencysById(int id)
        {
            return await consistencyRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Consistency>> CreateConsistency(Consistency Consistency)
        {
            var consistencys = await consistencyRepository.Create(Consistency);
            return consistencys;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsistency(int id)
        {
            var consistencys = await consistencyRepository.Delete(id);
            return consistencys;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsistency(int id, Consistency Consistency)
        {
            var consistencys = await consistencyRepository.Update(id, Consistency);
            return consistencys;
        }
    }
}