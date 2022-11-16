using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UnitOfWork : IDisposable
    {
        private NorthwindContext context;

        public UnitOfWork(NorthwindContext context)
        {
            this.context = context;
            categoryRepository = new(context);
            customerRepository = new(context);
            orderRepository = new(context);
            productRepository = new(context);
            supplierRepository = new(context);
        }

        private CategoryRepository categoryRepository;
        private CustomerRepository customerRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private SupplierRepository supplierRepository;
        public CategoryRepository CategoryRepository
        {
            get => categoryRepository;
        }

        public CustomerRepository CustomerRepository
        {
            get => customerRepository;
        }

        public OrderRepository OrderRepository
        {
            get => orderRepository;
        }

        public ProductRepository ProductRepository 
        {
            get => productRepository;
        }
        public SupplierRepository SupplierRepository 
        {
            get => supplierRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
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
    }
}
