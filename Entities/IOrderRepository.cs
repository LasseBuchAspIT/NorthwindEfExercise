using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int id);
        void InsertOrder(Order customer);
        void UpdateOrder(Order customer);
        void DeleteOrder(int id);
        void save();
    }
}
