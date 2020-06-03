using Lesson07.EFEntities;
using System;
using System.Data.Entity;

namespace Lesson07.Context
{
    public class EFContext : DbContext
    {
        public EFContext(string connectionString)
        {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseAlways<EFContext>());
            this.Database.Connection.ConnectionString = connectionString;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}