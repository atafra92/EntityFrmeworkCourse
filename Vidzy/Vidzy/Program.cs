using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using Vidzy.DAL;
using Vidzy.Models;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {

            using(var context = new VidzyDbContext())
            {
                var videos = new List<Video>
                {
                    new Video { Name = "Star Wars", ReleaseTime = DateTime.Now, VideoGenres = new List<VideoGenre>
                    {
                        new VideoGenre { GenreId = 4}
                    }
                    },
                    new Video { Name = "Troy", ReleaseTime = DateTime.Now, 
                        VideoGenres = new List<VideoGenre>
                    { 
                        new VideoGenre { GenreId = 2}
                    } 
                    }
                };
                foreach (var video in videos)
                {
                    context.Videos.Add(video);
                }

                context.SaveChanges();


            }

        }     
    }
}
