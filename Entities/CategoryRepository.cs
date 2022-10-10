using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private NorthwindContext context;

        public CategoryRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public void DeleteStudent(Category categoryId)
        {
            Category category = context.Categories.Find(categoryId);
            context.Categories.Remove(category);
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
            public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.Find(id);
        }

        public void InsertStudent(Category category)
        {
            context.Categories.Add(category);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateStudent(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
