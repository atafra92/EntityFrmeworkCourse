using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentAPI.EntityConfigurations
{
    public class CourseTagsConfiguration : IEntityTypeConfiguration<CourseTags>
    {
        public void Configure(EntityTypeBuilder<CourseTags> builder)
        {
            builder
                 .HasKey(t => new { t.CourseId, t.TagId });

            builder
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseTags)
                .HasForeignKey(pt => pt.CourseId);

            builder
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.CourseTags)
                .HasForeignKey(pt => pt.TagId);
        }
    }
}
