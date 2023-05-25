using FluentValidation;
using InLogic.Application.Models.Users;
using InLogic.Common;

namespace InLogic.Application.Validators.Users
{
    /// <summary>
    /// Represents an validator
    /// </summary>
    public class UserRegisterRequestModelValidator : AbstractValidator<UserRegisterRequestModel>
    {
        #region Ctor

        public UserRegisterRequestModelValidator()
        {
            RuleFor(m => m.Name)
                .Matches(RegexExtensions.NameRegex)
                .WithMessage(RegexExtensions.NameRegexMessage);

            RuleFor(m => m.Email)
                .NotEmpty()
                .MaximumLength(LengthConstraints.Email)
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty()
                .Length(LengthConstraints.PasswordLength.Min, LengthConstraints.PasswordLength.Max)
                .Matches(RegexExtensions.PasswordRegex)
                .WithMessage(RegexExtensions.PasswordRegexMessage);

            RuleFor(u => u.ConfirmPassword).NotEmpty().Equal(u => u.Password)
                .WithMessage(RegexExtensions.PasswordMatchRegexMessage);
        }

        #endregion

    }
}
