using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(NorthwindContext context) : base(context)
        {

        }
    }
}
