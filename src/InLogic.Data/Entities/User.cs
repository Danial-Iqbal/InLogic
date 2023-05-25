using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace InLogic.Data.Entities
{
    /// <summary>
    /// Represents an user
    /// </summary>
    [DebuggerDisplay("Id: {" + nameof(Id) + "}, Email: {" + nameof(Email) + "}")]
    public class User
    {
        #region Ctor

        public User(string? name, string email, string passwordHash, DateTime createdAt)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
        }

        #endregion

        #region Fields

        /// <summary>
        /// Gets the identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [ProtectedPersonalData]
        [PersonalData]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        [ProtectedPersonalData]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash
        /// </summary> 
        public string? PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the created at date time utc
        /// </summary>
        public DateTime CreatedAt { get; set; }

        #endregion

    }
}
