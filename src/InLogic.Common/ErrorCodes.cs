namespace InLogic.Common
{
    /// <summary>
    /// Represents an error codes
    /// </summary>
    public static class ErrorCodes
    {
        #region Exception codes

        /// <summary>
        /// Represents an exception
        /// </summary>
        public static class ExceptionCodes
        {
            public const string DuplicateOperation = "DuplicateOperation";
        }

        #endregion

        #region Entity codes

        /// <summary>
        /// Represents an exception
        /// </summary>
        public static class EntityCodes
        {
            public const string UserAlreadyExists = nameof(UserAlreadyExists);
        }

        #endregion
    }
}
