using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Data.Domain;

namespace Training.Data.EF.MigrationConfigurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasData(
               new Video
               {
                   Id = Guid.NewGuid(),
                   CreationDate = DateTime.Now,
                   DirectedBy = "Bong Joon Ho",
                   Duration = 132,
                   Genre = "Comedy, Drama, Trhiller",
                   ModifiedDate = DateTime.Now,
                   Name = "Parasite",
                   StudioId = new Guid("d9c734cf-76f6-4db6-839a-000000000001")
               },
               new Video
               {
                   Id = Guid.NewGuid(),
                   CreationDate = DateTime.Now,
                   DirectedBy = "Sam Mendez",
                   Duration = 119,
                   Genre = "Drama, War",
                   ModifiedDate = DateTime.Now,
                   Name = "1917",
                   StudioId = new Guid("d9c734cf-76f6-4db6-839a-000000000002")
               },
               new Video
               {
                   Id = Guid.NewGuid(),
                   CreationDate = DateTime.Now,
                   DirectedBy = "Martin Scorsese",
                   Duration = 209,
                   Genre = "Biography, Crime, Drama",
                   ModifiedDate = DateTime.Now,
                   Name = "The Irishman",
                   StudioId = new Guid("d9c734cf-76f6-4db6-839a-000000000003")
               },
               new Video
               {
                   Id = Guid.NewGuid(),
                   CreationDate = DateTime.Now,
                   DirectedBy = "Quentin Tarantino",
                   Duration = 161,
                   Genre = "Comedy, Drama",
                   ModifiedDate = DateTime.Now,
                   Name = "Once Upoin a Time... In Hollywood",
                   StudioId = new Guid("d9c734cf-76f6-4db6-839a-000000000004")
               }
               );
        }
    }
}
