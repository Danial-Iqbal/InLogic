using InLogic.Data.Repositories.Base;
using InLogic.Data.Entities;

namespace InLogic.Data.Repositories.Users
{
    /// <summary>
    /// Represents an user repository
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        #region Methods

        #region Get by email

        /// <summary>
        /// This method is used to get user by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>User</returns>
        Task<User?> GetByEmail(string email);

        #endregion

        #endregion
    }
}
