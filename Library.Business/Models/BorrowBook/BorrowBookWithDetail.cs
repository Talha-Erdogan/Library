using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Models.BorrowBook
{
    public class BorrowBookWithDetail :Library.Data.Entity.BorrowBook
    {
        //member columns
        public string Member_Name { get; set; }
        public string Member_LastName { get; set; }
        public string Member_TC { get; set; }
        public string Member_Phone { get; set; }
        
        //book columns
        public string Book_Name { get; set; }
    }
}
