using System.Diagnostics;

namespace InLogic.Application.Models.Users
{
    /// <summary>
    /// Represents an user register request model
    /// </summary>
    [DebuggerDisplay("Email: {" + nameof(Email) + "}")]
    public class UserRegisterRequestModel
    {
        #region Ctor

        public UserRegisterRequestModel(string? name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name
        /// </summary> 
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary> 
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password
        /// </summary>
        public string ConfirmPassword { get; set; }

        #endregion

    }
}
