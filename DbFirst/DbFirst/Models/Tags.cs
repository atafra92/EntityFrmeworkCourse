using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbFirst.Models
{
    public partial class Tags
    {
        public Tags()
        {
            CourseTags = new HashSet<CourseTags>();
        }

        public int TagId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CourseTags> CourseTags { get; set; }
    }
}
