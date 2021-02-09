using FluentAPI;
using FluentAPI.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DataAnnotations
{
    public class PlutoContext : DbContext
    {
        public PlutoContext()
        {

        }
        public PlutoContext(DbContextOptions<PlutoContext> options)
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
           modelBuilder.ApplyConfiguration(new CourseTagsConfiguration());
           modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}