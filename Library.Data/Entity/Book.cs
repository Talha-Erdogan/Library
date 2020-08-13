using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library.Data.Entity
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(50)]
        public string AuthorSurname { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public int? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        
    }
}
