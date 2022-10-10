using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private NorthwindContext context;

        public CustomerRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public Customer GetCustomerById(int id)
        {
            return context.Customers.Find(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }
    }
}
