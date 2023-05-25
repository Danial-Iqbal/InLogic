using System.Security.Cryptography;
using System.Text;

namespace InLogic.Common
{
    /// <summary>
    /// Represents an hash helper
    /// </summary>
    public static class HashHelper
    {
        #region Methods

        #region Get hash

        /// <summary>
        /// This method is used get hash of text
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns></returns>
        public static string GetHash(this string text)
        {
            // SHA512 is disposable by inheritance.  
            using var sha256 = SHA256.Create();

            // Send a sample text to hash.  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        #endregion

        #endregion

    }
}
