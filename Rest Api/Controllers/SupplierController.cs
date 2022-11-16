using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;

namespace Rest_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : Controller
    {
        private UnitOfWork unitOfWork;
        public SupplierController(NorthwindContext context)
        {
            unitOfWork = new(context);
        }

        [HttpGet]
        [Route("GetSupplierByIdAsync")]
        public async Task<ActionResult<Supplier>> GetSupplierFromIdAsync(int id)
        {
            var supplier = await unitOfWork.SupplierRepository.GetSupplierByIdAsync(id);
            return Ok(supplier);
        }

        [HttpGet]
        [Route("GetSupplierByNameAsync")]
        public async Task<ActionResult<Supplier>> GetSupplierFromNameAsync(string name)
        {
            var supplier = await unitOfWork.SupplierRepository.GetSupplierByNameAsync(name);
            return Ok(supplier);
        }


        [HttpPut]
        [Route("AddNewSupplierAsync")]
        public async Task AddNewSupplierAsync(string companyName, string? contactName, string? contactTitle = null, string? Address = null, string? city = null, string? region = null, string? postalCode = null, string? country = null, string? phone = null, string? fax = null, string? homePage = null)
        {
            Supplier s = new();
            s.CompanyName = companyName;
            s.ContactName = contactName;
            s.ContactTitle = contactTitle;
            s.Address = Address;
            s.City = city;
            s.Region = region;
            s.PostalCode = postalCode;
            s.Country = country;
            s.Phone = phone;
            s.Fax = fax;
            s.HomePage = homePage;

            await unitOfWork.SupplierRepository.AddNewSupplierAsync(s);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
