using FluentAPI;
using System.Collections.Generic;

namespace DataAnnotations
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<CourseTags> CourseTags { get; set; } = new List<CourseTags>();

    }
}