using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public IQueryable<Customer>
            GetCustomerByCompanyName(string name)
        {
            IQueryable<Customer> query = dbSet.Where(c => c.CompanyName == name);
            return query;
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            Customer ReturnCustomer = null;
            
            ReturnCustomer = await dbSet.Where(c => c.CustomerId == id.ToUpper()).FirstOrDefaultAsync();
            
            return ReturnCustomer;
        }

        public async Task CreateCustomerAsync(string companyId, string companyName, string contactName = null, string contactTitle = null, string address = null, string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            Customer customer = new();

                if(companyId.Length != 5)
                {
                    throw new ArgumentException("CustomerID must be 5 letters exact");
                }
                customer.CustomerId = companyId.ToUpper();
                customer.CompanyName = companyName;
                customer.ContactName = contactName;
                customer.ContactTitle = contactTitle;
                customer.Address = address;
                customer.City = city;
                customer.Region = region;
                customer.PostalCode = postalCode;
                customer.Country = country;
                customer.Phone = phone;
                customer.Fax = fax;

                await dbSet.AddAsync(customer);
        }
    }
}
