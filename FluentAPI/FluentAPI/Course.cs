using FluentAPI;
using System.Collections.Generic;

namespace DataAnnotations
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<CourseTags> CourseTags { get; set; } = new List<CourseTags>();

        public Cover Cover { get; set; }

    }
}