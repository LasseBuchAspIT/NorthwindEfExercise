using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(NorthwindContext context) : base(context)
        {
        }
    }
}
