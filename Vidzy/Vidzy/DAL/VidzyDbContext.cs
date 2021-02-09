using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Vidzy.Models;

namespace Vidzy.DAL
{
    public class VidzyDbContext : DbContext
    {
        public VidzyDbContext()
        {

        }
        public VidzyDbContext(DbContextOptions<VidzyDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();

            optionsBuilder.UseSqlServer(BuildConfig(builder));

        }

        string BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true) //get different environments(develompent, testing, production) but if not specified get a appsettings.production.json 
                .AddEnvironmentVariables();

            return builder.Build().GetConnectionString("Default");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
            .HasOne(p => p.Genre)
            .WithMany(b => b.Videos);

        }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
