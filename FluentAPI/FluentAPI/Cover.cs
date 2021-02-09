using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPI
{
    public class Cover
    {
        public int Id { get; set; }
        public Course Course { get; set; }
    }
}
