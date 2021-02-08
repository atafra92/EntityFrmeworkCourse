using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbFirst.Models
{
    public partial class Courses
    {
        public Courses()
        {
            CourseSections = new HashSet<CourseSections>();
            CourseTags = new HashSet<CourseTags>();
        }

        public int CourseId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Price { get; set; }
        public string LevelString { get; set; }
        public byte Level { get; set; }

        public virtual Authors Author { get; set; }
        public virtual ICollection<CourseSections> CourseSections { get; set; }
        public virtual ICollection<CourseTags> CourseTags { get; set; }
    }
}
