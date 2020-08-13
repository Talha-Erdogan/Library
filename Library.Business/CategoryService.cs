using Library.Business.Interfaces;
using Library.Data;
using Library.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Business
{
    public class CategoryService : ICategoryService
    {
        private IConfiguration _config;

        public CategoryService(IConfiguration config)
        {
            _config = config;
        }

        public List<Category> GetAll()
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.Category.ToList();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.Category.Where(p => p.Id == categoryId).FirstOrDefault();
            }
        }

        public int Add(Category category)
        {
            try
            {
                int result = 0;
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    dbContext.Entry(category).State = EntityState.Added;
                    result = dbContext.SaveChanges();
                }

                return result;
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Category category)
        {
            try
            {
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    dbContext.Entry(category).State = EntityState.Modified;
                    return dbContext.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    var category = dbContext.Category.Where(x => x.Id == id).FirstOrDefault();
                    if (category != null)
                    {
                        dbContext.Category.Remove(category);
                        return dbContext.SaveChanges();
                    }
                    return 0;
                }
            }
            catch
            {

                return 0;
            }
        }
    }
}
