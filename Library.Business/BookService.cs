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
    public class BookService : IBookService
    {
        private IConfiguration _config;

        public BookService(IConfiguration config)
        {
            _config = config;
        }

        public List<Book> GetAll()
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.Book.ToList();
            }
        }

        public Book GetById(int id)
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.Book.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public int Add(Book book)
        {
            try
            {
                int result = 0;
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    dbContext.Entry(book).State = EntityState.Added;
                    result = dbContext.SaveChanges();
                }

                return result;
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Book book)
        {
            try
            {
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    dbContext.Entry(book).State = EntityState.Modified;
                    return dbContext.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int id,int deletedBy)
        {
            try
            {
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    var book = dbContext.Book.Where(x => x.Id == id).FirstOrDefault();
                    if (book != null)
                    {
                        book.DeletedBy = deletedBy;
                        book.DeletedDateTime = DateTime.Now;
                        dbContext.Entry(book).State = EntityState.Modified;
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
