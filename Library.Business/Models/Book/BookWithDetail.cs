using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Models.Book
{
    public class BookWithDetail :Data.Entity.Book
    {
        public string Category_Name { get; set; }
    }
}
