using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
   public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetCategoryById(int categoryId);
        int Add(Category category);
        int Update(Category category);
        int Delete(int id);
    }
}
