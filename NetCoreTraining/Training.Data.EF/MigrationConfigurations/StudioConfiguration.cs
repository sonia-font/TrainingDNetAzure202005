using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Training.Data.Domain;

namespace Training.Data.EF.MigrationConfigurations
{
    class StudioConfiguration : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasData(
               new Studio
               {
                   Id = new Guid("d9c734cf-76f6-4db6-839a-000000000001"),
                   CreationDate = DateTime.Now,                   
                   ModifiedDate = DateTime.Now,
                   Name = "Studio 1"
               },
               new Studio
               {
                   Id = new Guid("d9c734cf-76f6-4db6-839a-000000000002"),
                   CreationDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Name = "Studio 2"
               },
               new Studio
               {
                   Id = new Guid("d9c734cf-76f6-4db6-839a-000000000003"),
                   CreationDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Name = "Studio 3"
               },
               new Studio
               {
                   Id = new Guid("d9c734cf-76f6-4db6-839a-000000000004"),
                   CreationDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   Name = "Studio 4"
               }
               );
        }
    }
}
