using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Vidzy.Models;

namespace Vidzy.EntityTypeConfigurations
{
    public class VideoTagsConfiguration : IEntityTypeConfiguration<VideoTags>
    {
        public void Configure(EntityTypeBuilder<VideoTags> builder)
        {
            builder
                .HasKey(t => new { t.TagId, t.VideoId });

            builder
                .HasOne(p => p.Tag)
                .WithMany(b => b.VideoTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(p => p.Video)
                .WithMany(b => b.VideoTags)
                .HasForeignKey(x => x.VideoId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
