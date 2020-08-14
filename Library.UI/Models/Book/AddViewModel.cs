using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Models.Book
{
    public class AddViewModel
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(50)]
        public string AuthorSurname { get; set; }

        //select list
        public List<SelectListItem> CategoryList { get; set; }
    }
}
