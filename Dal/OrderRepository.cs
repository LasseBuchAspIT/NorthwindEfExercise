using Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Order> GetAllOrdersFromCustomer(Customer customer)
        {
            return dbSet.Where(o => o.CustomerId == customer.CustomerId).ToList();
        }

        public List<Order> GetAllOngoingOrdersFromCustomer(Customer customer)
        {
            return dbSet.Where(o => o.CustomerId == customer.CustomerId && o.RequiredDate > DateTime.Now).ToList();
        }
        public List<Order> GetAllOngoingOrdersFromCustomer(string id)
        {
            Customer customer = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return dbSet.Where(o => o.CustomerId == customer.CustomerId && o.RequiredDate > DateTime.Now).ToList();
        }


    }
}
