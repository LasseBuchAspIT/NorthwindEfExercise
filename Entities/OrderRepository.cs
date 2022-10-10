using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        NorthwindContext context;

        public OrderRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public void DeleteOrder(int id)
        {
            Order order = context.Orders.Find(id);
            context.Remove(order);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Find(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.ToList();
        }

        public void InsertOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public void save()
        {
           context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }
    }
}
