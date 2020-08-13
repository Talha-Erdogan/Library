using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(int id);
        int Add(Book book);
        int Update(Book book);
        int Delete(int id, int deletedBy);
    }
}
