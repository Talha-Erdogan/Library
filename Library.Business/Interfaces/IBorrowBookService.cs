using Library.Business.Models.BorrowBook;
using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IBorrowBookService
    {
        List<BorrowBook> GetAll();
        List<BorrowBookWithDetail> GetAllBorrowedBooks();
        List<BorrowBookWithDetail> GetAllBroughtBookList();
        BorrowBook GetBorrowBookById(int borrowBookId);
        int Add(BorrowBook borrowBook);
        int Update(BorrowBook borrowBook);
    }
}
