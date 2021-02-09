using System;
using System.Collections.Generic;
using System.Text;

namespace Vidzy.Models
{
    public class VideoTags
    {
        public int VideoId { get; set; }
        public int TagId { get; set; }
        public Video Video { get; set; }
        public Tag Tag { get; set; }
    }
}
