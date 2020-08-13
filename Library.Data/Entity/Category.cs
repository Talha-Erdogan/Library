using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entity
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
