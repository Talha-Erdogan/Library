using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Models.Profile
{
    public class AddViewModel
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Code { get; set; }

        [StringLength(150)]
        public string Name { get; set; }
    }
}
