namespace InLogic.Common
{
    /// <summary>
    /// Represents an length constraints
    /// </summary>
    public static class LengthConstraints
    {
        #region User

        public const int PersonName = 50;

        public const int Email = 256;

        public static readonly (int Min, int Max) PasswordLength = (8, 30);

        #endregion
    }
}