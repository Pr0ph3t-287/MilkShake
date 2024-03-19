using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<MilkshakeConfig> configRepository;

        public ConfigController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            configRepository = new ConfigRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MilkshakeConfig>>> GetConfigs()
        {
            var configs = await configRepository.Get();
            return configs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MilkshakeConfig>> GetConfigsById(int id)
        {
            return await configRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<MilkshakeConfig>> CreateConfig(MilkshakeConfig Config)
        {
            var configs = await configRepository.Create(Config);
            return configs;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfig(int id)
        {
            var configs = await configRepository.Delete(id);
            return configs;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfig(int id, MilkshakeConfig Config)
        {
            var configs = await configRepository.Update(id, Config);
            return configs;
        }
    }
}