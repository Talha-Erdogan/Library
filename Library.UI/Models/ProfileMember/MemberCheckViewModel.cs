﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.UI.Models.ProfileMember
{
    public class MemberCheckViewModel
    {
        public bool Checked { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
