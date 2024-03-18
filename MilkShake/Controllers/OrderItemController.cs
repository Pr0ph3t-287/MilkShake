using Microsoft.AspNetCore.Mvc;
using MilkShake.Models;
using MilkShake.Repository;
using MilkShake.Services;
using MilkShake.UnitOfWork;

namespace MilkShake.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<OrderItem> orderItemRepository;

        public OrderItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            orderItemRepository = new OrderItemRepository(_unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            var orderItems = await orderItemRepository.Get();
            return orderItems;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemsById(int id)
        {
            return await orderItemRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> CreateOrderItem(OrderItem OrderItem)
        {
            var orderItems = await orderItemRepository.Create(OrderItem);
            return orderItems;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItems = await orderItemRepository.Delete(id);
            return orderItems;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderItem(int id, OrderItem OrderItem)
        {
            var orderItems = await orderItemRepository.Update(id, OrderItem);
            return orderItems;
        }
    }
}