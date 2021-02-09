﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vidzy.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime ReleaseTime { get; set; }

        public List<VideoGenre> VideoGenres { get; set; } = new List<VideoGenre>();
    }
}