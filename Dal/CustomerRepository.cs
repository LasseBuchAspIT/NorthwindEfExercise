using Entities;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
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
        /// <summary>
        /// Gets customer by exact company name.
        /// Will return null if no company with sent name found
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<Customer> GetCustomerByCompanyName(string name)
        {
            IQueryable<Customer> query = dbSet.Where(c => c.CompanyName == name);
            return query;
        }
    }
}
