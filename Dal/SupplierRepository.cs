using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SupplierRepository : GenericRepository<Supplier>
    {
        public SupplierRepository(NorthwindContext context) : base(context)
        {

        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            Supplier supplier = null;

            supplier = await dbSet.Where(s => s.SupplierId == id).FirstOrDefaultAsync();

            return supplier;
        }


        public async Task<Supplier> GetSupplierByNameAsync(string name)
        {
            Supplier supplier = null;

            supplier = await dbSet.Where(s => s.CompanyName == name).FirstOrDefaultAsync();

            return supplier;
        }

        public async Task AddNewSupplierAsync(Supplier supplier)
        {
            await dbSet.AddAsync(supplier);
        }
    }
}
