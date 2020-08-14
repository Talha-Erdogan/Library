using Library.Business.Models.Book;
using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        List<BookWithDetail> GetAllWithDetail();
        Book GetById(int id);
        int Add(Book book);
        int Update(Book book);
        int Delete(int id, int deletedBy);
    }
}
