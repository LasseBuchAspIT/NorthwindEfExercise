using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(NorthwindContext context) : base(context)
        {

        }
    }
}
