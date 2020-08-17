using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Models.BorrowBook
{
    public class AddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Member is reqired.")]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Book is reqired.")]
        public int BookId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ExpirationDate { get; set; }
        public bool IsBring { get; set; } = false;
        public DateTime? BringDate { get; set; }
        public List<SelectListItem> BookList { get; set; }
        public List<SelectListItem> MemberList { get; set; }
    }
}
