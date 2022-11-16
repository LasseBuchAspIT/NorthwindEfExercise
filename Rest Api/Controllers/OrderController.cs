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
        [Route("test1")]
        public async Task<ActionResult<List<Order>>> GetAllOrdersAsync()
        {
            List<Order> returnList = new();
            await Task.Run(() =>
            {
                returnList = unitOfWork.OrderRepository.Get().ToList();
            });
            return returnList;
        }

        [HttpGet]
        [Route("test2")]
        public ActionResult<List<Order>> GetAllOrders()
        {
            List<Order> returnList = new();
            returnList = unitOfWork.OrderRepository.Get().ToList();
            return Ok(returnList);
        }



        [HttpGet]
        [Route("GetAllOngoingOrdersForCustomer")]
        public async Task<ActionResult<List<Order>>> GetAllOngoingOrdersForCustomer(string id)
        {
            List<Order> returnList = new();
            await Task.Run(() =>
            {
                returnList = unitOfWork.OrderRepository.GetAllOngoingOrdersFromCustomer(id);
            });
            return Ok(returnList);
        }
    }
}
