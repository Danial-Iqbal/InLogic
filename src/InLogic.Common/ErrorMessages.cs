namespace InLogic.Common
{
    /// <summary>
    /// Represents an error messages
    /// </summary>
    public static class ErrorMessages
    {
        #region Regex messages

        /// <summary>
        /// Represents an regex messages
        /// </summary>
        public static class RegexMessages
        {
            public const string PasswordRegexMessage = "Password must contain at least one capital alphabet, one small alphabet, one digit and one special character";
            public const string PasswordMatchRegexMessage = "Confirm password should be equal to password";
            public const string NameRegexMessage = "Name can only contain alphabets";
            public const string EmailRegexMessage = "Invalid characters in email address";
        }

        #endregion

        #region Entity messages

        /// <summary>
        /// Represents an entity messages
        /// </summary>
        public static class EntityMessages
        {
            public const string UserAlreadyExists = "User already exists";
        }

        #endregion
    }
}
