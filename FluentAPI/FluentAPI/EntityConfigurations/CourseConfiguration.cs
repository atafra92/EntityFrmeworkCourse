using DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPI.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                 .Property(c => c.Name)
                 .IsRequired()
                 .HasMaxLength(255);

            builder
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //override default behavior(we dont need to specify hasforeignkey() because in EF Core it is defined as AuthorId and not Author_Id)
            builder
                .HasOne(c => c.Author)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //configuring one-to-one relationship 
            builder
                .HasOne(c => c.Cover)
                .WithOne(c => c.Course)
                .HasForeignKey<Cover>(c => c.Id);
        }
    }
}
