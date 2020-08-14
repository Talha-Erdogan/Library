using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Library.Data.Entity
{
    [Table("Member")]
    public class Member
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [StringLength(12)]
        [Required]
        public string TC { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public bool Panel { get; set; }

        [StringLength(100)]
        public string ImageFilePath { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(150)]
        public string Password { get; set; }

    }
}
