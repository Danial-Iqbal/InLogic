namespace InLogic.Data.Repositories.Base
{
    /// <summary>
    /// Represents an base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Get by identifier

        /// <summary>
        /// This method is used to get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns></returns>
        ValueTask<TEntity?> GetByIdAsync(Guid id);

        #endregion

        #region Add

        /// <summary>
        /// This method is used to add entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        ValueTask AddAsync(TEntity entity);

        #endregion

        #region Update

        /// <summary>
        /// This method is used to update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        #endregion

        #region Delete

        /// <summary>
        /// This method is used to delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// This method is used to delete entity by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask DeleteAsync(Guid id);

        #endregion

    }
}
