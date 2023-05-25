using System.Text.RegularExpressions;

namespace InLogic.Common
{
    /// <summary>
    /// Represents an regex extensions
    /// </summary>
    public static class RegexExtensions
    {
        #region Password regex

        public const string PasswordRegexExpression = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=_+'\"\\/,.<>;:`~|]).{8,}$";

        public static readonly Regex PasswordRegex =
            new Regex(PasswordRegexExpression, RegexOptions.None, TimeSpan.FromSeconds(5));

        public const string PasswordRegexMessage = ErrorMessages.RegexMessages.PasswordRegexMessage;

        public const string PasswordMatchRegexMessage = ErrorMessages.RegexMessages.PasswordMatchRegexMessage;

        #endregion

        #region Email regex

        private const string EmailRegexExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public static readonly Regex EmailRegex =
            new Regex(EmailRegexExpression, RegexOptions.None, TimeSpan.FromSeconds(5));

        public const string EmailRegexMessage = ErrorMessages.RegexMessages.EmailRegexMessage;

        #endregion

        #region Name regex

        private const string NameRegexExpression = "^[a-zA-Z- ]*$";

        public static readonly Regex NameRegex =
            new Regex(NameRegexExpression, RegexOptions.None, TimeSpan.FromSeconds(5));

        public const string NameRegexMessage = ErrorMessages.RegexMessages.NameRegexMessage;

        #endregion

    }
}
