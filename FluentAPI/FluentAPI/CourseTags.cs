using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPI
{
    public class CourseTags
    {
        public int CourseId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public Course Course { get; set; }
    }
}
