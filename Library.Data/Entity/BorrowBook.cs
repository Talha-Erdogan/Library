using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entity
{
    [Table("BorrowBook")]
    public class BorrowBook
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int BookId { get; set; }

        public bool IsBring { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public DateTime ExpirationDateTime { get; set; }

    }
}
