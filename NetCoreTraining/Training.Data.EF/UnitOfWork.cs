using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Training.Data.Domain;
using Training.Data.EF.MigrationConfigurations;

namespace Training.Data.EF
{
    public interface IEfUnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///     Returns a IDbSet instance for access to entities of the given type in the context,
        ///     the ObjectStateManager, and the underlying store.
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    }

    public class UnitOfWork : DbContext, IEfUnitOfWork
    {
        #region Constructors

        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
        {
        }

        #endregion

        #region DbSets

        public DbSet<Video> Videos { get; set; }
        public DbSet<Studio> Studios { get; set; }

        #endregion

        #region IUnitOfWork Implementation

        public void CommitChanges()
        {
            SaveChanges();
        }

        public void RollbackChanges()
        {
            ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VideoConfiguration());
            modelBuilder.ApplyConfiguration(new StudioConfiguration());
        }

    }
}