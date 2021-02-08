using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbFirst.Models
{
    public partial class CourseTags
    {
        public int CourseId { get; set; }
        public int TagId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
