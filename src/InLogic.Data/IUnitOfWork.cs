using InLogic.Data.Repositories.Users;

namespace InLogic.Data
{
    /// <summary>
    /// Represents an unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        #region Methods

        /// <summary>
        /// User repository
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// This method is used to save changes
        /// </summary>
        /// <returns></returns>
        Task<int> CompleteAsync();

        #endregion

    }
}
