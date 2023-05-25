using InLogic.Data.Data;
using InLogic.Data.Repositories.Users;

namespace InLogic.Data
{
    /// <summary>
    /// Represents an unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly ApplicationDbContext _dbContext;

        private bool _disposed;

        #endregion

        #region Ctor

        public UnitOfWork(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            UserRepository = userRepository;
        }

        #endregion

        #region Util

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// User repository
        /// </summary>
        public IUserRepository UserRepository { get; }

        /// <summary>
        /// This method is used to save changes
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion






    }
}