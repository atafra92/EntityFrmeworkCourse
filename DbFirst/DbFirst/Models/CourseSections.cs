using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbFirst.Models
{
    public partial class CourseSections
    {
        public int SectionId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }

        public virtual Courses Course { get; set; }
    }
}
