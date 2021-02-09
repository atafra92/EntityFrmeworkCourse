using System;
using System.Collections.Generic;
using System.Text;

namespace Vidzy.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VideoTags> VideoTags { get; set; } = new List<VideoTags>();

    }
}
