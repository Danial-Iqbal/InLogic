using InLogic.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace InLogic.Data.Repositories.Base
{
    /// <summary>
    /// Represents an base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region Fields

        protected readonly DbSet<TEntity> DbSet;

        #endregion

        #region Ctor

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            DbSet = dbContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        #region Get by identifier

        /// <summary>
        /// This method is used to get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns></returns>
        public async ValueTask<TEntity?> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);

        #endregion

        #region Add

        /// <summary>
        /// This method is used to add entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        public async ValueTask AddAsync(TEntity entity) => await DbSet.AddAsync(entity);

        #endregion

        #region Update

        /// <summary>
        /// This method is used to update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity) => DbSet.Update(entity);

        #endregion

        #region Delete

        /// <summary>
        /// This method is used to delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity) => DbSet.Remove(entity);

        /// <summary>
        /// This method is used to delete entity by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async ValueTask DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null) DbSet.Remove(entity);
        }

        #endregion

        #endregion

    }
}
