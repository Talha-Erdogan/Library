using Library.Business.Interfaces;
using Library.Business.Models.Book;
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
                return dbContext.Book.Where(x=>x.IsDeleted==false).ToList();
            }
        }

        public List<BookWithDetail> GetAllWithDetail()
        {
            List<BookWithDetail> resultList = null;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                //return dbContext.Book.ToList();
                resultList = (from b in dbContext.Book
                                           join c in dbContext.Category on b.CategoryId equals c.Id
                              where b.IsDeleted==false
                                           select new BookWithDetail()
                                           {
                                              Id = b.Id,
                                              CategoryId = b.CategoryId,
                                              Name = b.Name,
                                              AuthorName =b.AuthorName,
                                              AuthorSurname =b.AuthorSurname,
                                              
                                              Category_Name =c.Name
                                           }).ToList();
            }
            return resultList;
        }
        public Book GetById(int id)
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.Book.Where(p => p.Id == id&& p.IsDeleted==false).FirstOrDefault();
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
                        book.IsDeleted = true;
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
