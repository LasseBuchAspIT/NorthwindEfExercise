using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(NorthwindContext context) : base(context)
        {
        }

        public List<Product> GetAllProductsOfCategory(Category category)
        {
            return dbSet.Where(x => x.Category == category).ToList();
        }

        public List<Product> GetAllProductsOverPrice(decimal price)
        {
            return dbSet.Where(p => p.UnitPrice > price).ToList();
        }
        
        public List<Product> GetAllProductsUnderPrice(decimal price)
        {
            return dbSet.Where(p => p.UnitPrice < price).ToList();
        }

        public Product GetProductByName(string name)
        {
            return dbSet.Where(p => p.ProductName == name).First();
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await dbSet.Where(p => p.ProductName == name).FirstOrDefaultAsync();
        }

        public async Task AddNewProdcutWithExistingSupplierAsync(Product p)
        {
            await dbSet.AddAsync(p);
        }
    }
}
