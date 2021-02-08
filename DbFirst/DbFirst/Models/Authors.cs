﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbFirst.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Courses = new HashSet<Courses>();
        }

        public int AuthorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Courses> Courses { get; set; }
    }
}
