using Entities;
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
    }


}
