using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void InsertStudent(Category category);
        void DeleteStudent(Category categoryId);
        void UpdateStudent(Category category);
        void Save();


    }
}
