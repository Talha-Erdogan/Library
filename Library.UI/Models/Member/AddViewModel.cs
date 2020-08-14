using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Models.Member
{
    public class AddViewModel
    {
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

        //image
        public IFormFile ImageFilePath { get; set; }
        //image Name
        public string ImageName { get; set; }
    }
}
