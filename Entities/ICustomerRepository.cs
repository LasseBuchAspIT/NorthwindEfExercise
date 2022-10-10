using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICustomerRepository : IDisposable
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        void InsertCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
        void save();
    }
}
