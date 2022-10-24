using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Rest_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private UnitOfWork unitOfWork;

        public OrderController(NorthwindContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrdersAsync()
        {
            List<Order> returnList = new();
            await Task.Run(() =>
            {
                returnList = unitOfWork.OrderRepository.Get().ToList();
            });
            return Ok(returnList);
        }
    }
}
