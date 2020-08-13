using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Data.Entity
{
    [Table("ProfileMember")]
    public class ProfileMember
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public int ProfileId { get; set; }

        [Required]
        public int MemberId { get; set; }
    }
}
