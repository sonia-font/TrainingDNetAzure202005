using System;
using System.Collections.Generic;
using System.Text;
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
                   StudioId= new Guid("d9c734cf-76f6-4db6-839a-013ff6bbc875")
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
                   StudioId = new Guid("4328e74c-d820-4f6d-8fb0-fd49a552d65d")
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
                   StudioId = new Guid("1d3e5008-5c35-4180-a898-55c5f5ca7fe8")
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
                   StudioId = new Guid("1d3e5008-5c35-4180-a898-55c5f5ca7fe8")
               }
               );
        }
    }
}
