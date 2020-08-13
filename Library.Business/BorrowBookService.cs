using Library.Business.Interfaces;
using Library.Data;
using Library.Data.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Library.Business.Models.BorrowBook;

namespace Library.Business
{
    public class BorrowBookService : IBorrowBookService
    {
        private IConfiguration _config;

        public BorrowBookService(IConfiguration config)
        {
            _config = config;
        }

        public List<BorrowBook> GetAll()
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.BorrowBook.ToList();
            }
        }

        //ödünç verilen kitaplar listesi
        public List<BorrowBookWithDetail> GetAllBorrowedBooks()
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var result = (from b in dbContext.Book
                              join bb in dbContext.BorrowBook on b.Id equals bb.BookId
                              join m in dbContext.Member on bb.MemberId equals m.Id
                              where bb.IsBring == false
                              select new BorrowBookWithDetail()
                              {
                                  Id = bb.Id,
                                  MemberId = bb.MemberId,
                                  BookId = bb.BookId,
                                  ExpirationDateTime =bb.ExpirationDateTime,
                                  CreatedBy = bb.CreatedBy,
                                  CreatedDateTime = bb.CreatedDateTime,
                                  IsBring = bb.IsBring,
                                  Member_Name = m.Name,
                                  Member_LastName = m.LastName,
                                  Member_TC = m.TC,
                                  Member_Phone = m.Phone,
                                  Book_Name = b.Name,
                              }).ToList();
                return result;
            }
        }

        //getirilen kitaplar listesi
        public List<BorrowBookWithDetail> GetAllBroughtBookList()
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var result = (from b in dbContext.Book
                              join bb in dbContext.BorrowBook on b.Id equals bb.BookId
                              join m in dbContext.Member on bb.MemberId equals m.Id
                              where bb.IsBring == true
                              select new BorrowBookWithDetail()
                              {
                                  Id = bb.Id,
                                  MemberId = bb.MemberId,
                                  BookId = bb.BookId,
                                  ExpirationDateTime = bb.ExpirationDateTime,
                                  CreatedBy = bb.CreatedBy,
                                  CreatedDateTime = bb.CreatedDateTime,
                                  ModifiedBy = bb.ModifiedBy,
                                  ModifiedDateTime = bb.ModifiedDateTime,
                                  IsBring = bb.IsBring,
                                  Member_Name = m.Name,
                                  Member_LastName = m.LastName,
                                  Member_TC = m.TC,
                                  Member_Phone = m.Phone,
                                  Book_Name = b.Name,
                              }).ToList();
                return result;
            }
        }

        public BorrowBook GetBorrowBookById(int borrowBookId)
        {
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                return dbContext.BorrowBook.Where(p => p.Id == borrowBookId).FirstOrDefault();
            }
        }

        public int Add(BorrowBook borrowBook)
        {
            try
            {
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    dbContext.Entry(borrowBook).State = EntityState.Added;
                    return dbContext.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int Update(BorrowBook borrowBook)
        {
            try
            {
                using (AppDBContext dbContext = new AppDBContext(_config))
                {
                    dbContext.Entry(borrowBook).State = EntityState.Modified;
                    return dbContext.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
