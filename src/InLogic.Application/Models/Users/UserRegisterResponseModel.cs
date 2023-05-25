using System.Diagnostics;

namespace InLogic.Application.Models.Users
{
    /// <summary>
    /// Represents an user register response model
    /// </summary>
    [DebuggerDisplay("Id: {" + nameof(Id) + "}")]
    public class UserRegisterResponseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public Guid Id { get; set; }

        #endregion

    }
}
