﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Training.Data.EF
{
    public class Repository<TEntity, TEntityId>
        : IRepository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
    {
        #region Members

        private readonly IEfUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public Repository(IEfUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        private DbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }

        #endregion

        #region IRepository Implementation

        public void Add(TEntity item)
        {
            GetSet().Add(item);
            _unitOfWork.CommitChanges();
        }

        public async Task AddAsync(TEntity item)
        {
            await GetSet().AddAsync(item);
            _unitOfWork.CommitChanges();
        }

        public TEntity Get(TEntityId id)
        {
            return !id.Equals(default(TEntityId)) ? GetSet().Find(id) : null;
        }

        public async Task<TEntity> GetAsync(TEntityId id)
        {
            return !id.Equals(default(TEntityId)) ? await GetSet().FindAsync(id) : null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return GetSet().AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await GetSet().ToListAsync();
        }

        public void Remove(TEntity item)
        {
            GetSet().Remove(item);
            _unitOfWork.CommitChanges();
        }

        public async Task RemoveAsync(TEntity item)
        {
            await Task.Run(() => GetSet().Remove(item));
            _unitOfWork.CommitChanges();
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        #endregion
    }
}