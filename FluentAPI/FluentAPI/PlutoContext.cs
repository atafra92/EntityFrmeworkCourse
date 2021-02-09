using FluentAPI;
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
            modelBuilder.Entity<CourseTags>()
                .HasKey(t => new { t.CourseId, t.TagId });

            modelBuilder.Entity<CourseTags>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseTags)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<CourseTags>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.CourseTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //ovveride default behavior(we dont need to specify hasforeignkey() because in EF Core it is defined as AuthorId and not Author_Id)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            //configuring one-to-one relationship 
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Cover)
                .WithOne(c => c.Course)
                .HasForeignKey<Cover>(c => c.Id);
                
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}