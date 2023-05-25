using InLogic.Application.Models.Users;

namespace InLogic.Application.Services.Users
{
    /// <summary>
    /// Represents an user repository
    /// </summary>
    public interface IUserService
    {
        #region Methods

        #region Register

        /// <summary>
        /// This method is used to register user
        /// </summary>
        /// <param name="model">User register request model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User register response model</returns>
        Task<UserRegisterResponseModel> RegisterAsync(UserRegisterRequestModel model, CancellationToken cancellationToken);

        #endregion

        #endregion
    }
}
