using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vidzy.Models;

namespace Vidzy.EntityTypeConfigurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            //does not need to specify this because it is inferred automatically
            builder
            .HasOne(p => p.Genre)
            .WithMany(b => b.Videos)
            .IsRequired();

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
