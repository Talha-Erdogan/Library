using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Models.ProfileMember
{
    public class BatchEditViewModel
    {
        public int? ProfileId { get; set; }
        public List<SelectListItem> ProfileSelectList { get; set; }
       
        public List<MemberCheckViewModel> MemberList { get; set; }
        public List<MemberCheckViewModel> MemberWhichIsNotIncludeList { get; set; }

        public string SubmitType { get; set; }
    }
}
