using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Data.Domain;

namespace Training.Data.EF.MigrationConfigurations
{
    public class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasData(
                new Studio {
                    CreationDate=DateTime.Now, 
                    ModifiedDate=DateTime.Now,
                    Id=new Guid("d9c734cf-76f6-4db6-839a-013ff6bbc875"),
                    Name="Studio 1"
                },
                new Studio
                {
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = new Guid("4328e74c-d820-4f6d-8fb0-fd49a552d65d"),
                    Name = "Universal Studios"
                },

                new Studio
                {
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = new Guid("1d3e5008-5c35-4180-a898-55c5f5ca7fe8"),
                    Name = "Studio 3"
                },

                new Studio
                {
                    CreationDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = new Guid("bce0d965-1fe6-46e7-bc4c-94ac3628091f"),
                    Name = "Studio 4"
                }

            );
           
        }
    }
}

