using Microsoft.AspNetCore.Mvc;

namespace Rest_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private UnitOfWork unitOfWork;
        public CustomerController(NorthwindContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("GetCustomerByIdAsync")]
        public async Task<ActionResult<Customer>> GetCustomerByIdAsync(string id)
        {
            return Ok(await unitOfWork.CustomerRepository.GetCustomerByIdAsync(id));
        }

        [HttpPut]
        [Route("CreateNewCustomerAsync")]
        public async Task CreateNewCustomerAsync(string id, string companyName, string? contactName = null, string? contactTitle = null, string? address = null, string? city = null, string? region = null, string? postalCode = null, string? country = null, string? phone = null, string? fax = null)
        {
            await unitOfWork.CustomerRepository.CreateCustomerAsync(id, companyName, contactName, contactTitle, address, city, region, postalCode, country, phone, fax);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
