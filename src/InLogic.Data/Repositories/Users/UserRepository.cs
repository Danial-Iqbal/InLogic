using InLogic.Data.Data;
using InLogic.Data.Repositories.Base;
using InLogic.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InLogic.Data.Repositories.Users
{
    /// <summary>
    /// Represents an user repository
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Fields



        #endregion

        #region Ctor

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        #endregion

        #region Methods

        #region Get by email

        /// <summary>
        /// This method is used to get user by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>User</returns>
        public async Task<User?> GetByEmail(string email) => await DbSet.FirstOrDefaultAsync(u => u.Email == email);

        #endregion

        #endregion

    }
}
