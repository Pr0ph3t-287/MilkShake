using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<Order> orderRepository;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            orderRepository = new OrderRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await orderRepository.Get();
            return orders;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrdersById(int id)
        {
            return await orderRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order Order)
        {
            var orders = await orderRepository.Create(Order);
            return orders;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orders = await orderRepository.Delete(id);
            return orders;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, Order Order)
        {
            var orders = await orderRepository.Update(id, Order);
            return orders;
        }
    }
}