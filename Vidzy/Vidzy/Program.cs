using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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
                //var videos = new List<Video>
                //{
                //    new Video { Name = "Star Wars", ReleaseTime = DateTime.Now, Classification = Classification.Gold },
                //    new Video { Name = "Troy", ReleaseTime = DateTime.Now, Classification = Classification.Platinum }
                //};

                //foreach (var video in videos)
                //{
                //    context.Videos.Add(video);
                //}

                var videos = context.Videos.ToList();

                //foreach (var video in videos)
                //{
                //  context.Videos.Remove(video);
                //}

                videos[0].Classification = Classification.Platinum;
                videos[1].Classification = Classification.Gold;
                foreach (var video in videos)
                {
                    context.Videos.Update(video);
                }
                context.SaveChanges();


            }

        }     
    }
}
