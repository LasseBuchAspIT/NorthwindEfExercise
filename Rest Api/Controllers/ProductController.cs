using Microsoft.AspNetCore.Mvc;

namespace Rest_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private UnitOfWork unitOfWork;

        public ProductController(NorthwindContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProductsWithSupplier()
        {
            List<Product> returnList = new List<Product>();
            await Task.Run(() =>
            {
                returnList = unitOfWork.ProductRepository.Get().ToList();
            });
            return Ok(returnList);
        }

        [HttpGet]
        [Route("GetProductsOverPrice")]
        public async Task<ActionResult<List<Product>>> GetAllProductsOver(decimal price)
        {
            List<Product> returnList = new List<Product>();
            await Task.Run(() =>
            {
                returnList = unitOfWork.ProductRepository.GetAllProductsOverPrice(price);
            });
            return Ok(returnList);
        }


        [HttpGet]
        [Route("GetProductsUnderPrice")]
        public async Task<ActionResult<List<Product>>> GetAllProductsUnder(decimal price)
        {
            List<Product> returnList = new List<Product>(); 
            await Task.Run(() =>
            {
                returnList = unitOfWork.ProductRepository.GetAllProductsUnderPrice(price);
            });
            return Ok(returnList);
        }

        [HttpPut]
        [Route("AddNewProductWithExistingSupplier")]
        public async Task<ActionResult> AddNewProductWithExistingSupplier(string productName, int supplierId, bool discontinued, int CategoryId = 1, string quantityPerUnit = null, decimal unitprice = 0, short unitsInStock = 0, short unitsOnOrder = 0, short reorderLevel = 0)
        {
            Task<Supplier> SupplierExists = unitOfWork.SupplierRepository.GetSupplierByIdAsync(supplierId);
            Product p = new Product();
            p.UnitPrice = unitprice;
            p.ProductName = productName;
            p.SupplierId = supplierId;
            p.CategoryId = CategoryId;
            p.Discontinued = discontinued;
            p.QuantityPerUnit = quantityPerUnit;
            p.UnitsInStock = unitsInStock;
            p.UnitsOnOrder = unitsOnOrder;
            p.ReorderLevel = reorderLevel;

            await SupplierExists;

            if(SupplierExists.Result.CompanyName == null || supplierId != SupplierExists.Result.SupplierId)
            {
                return BadRequest("Supplier doesnt exist " + SupplierExists.Result.SupplierId);
            }

                
            await unitOfWork.ProductRepository.AddNewProdcutWithExistingSupplierAsync(p);
            await unitOfWork.SaveChangesAsync();

            return Ok("Product added");
        }

        [HttpGet]
        [Route("FindProductByName")]
        public async Task<ActionResult<Product>> GetProductByName(string productName)
        {
            return Ok(await unitOfWork.ProductRepository.GetProductByNameAsync(productName));
        }
    }
}
