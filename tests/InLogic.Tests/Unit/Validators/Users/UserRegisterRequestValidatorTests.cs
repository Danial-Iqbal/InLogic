using FluentAssertions;
using InLogic.Application.Models.Users;
using InLogic.Application.Validators.Users;
using InLogic.Common;

namespace InLogic.Tests.Unit.Validators.Users
{
    /// <summary>
    /// Represents an register validator tests
    /// </summary>
    public class UserRegisterRequestValidatorTests
    {

        #region Valid 

        /// <summary>
        /// This method is used to test RegisterUserValidRequest
        /// </summary>
        [Fact]
        public void RegisterUserValidRequest()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", "danyal@inlogic.com", "String@123", "String@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert 

            // assert
            Assert.True(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region Invalid

        #region RegisterUserInvalidRequest

        /// <summary>
        /// This method is used to test RegisterUserInvalidRequest
        /// </summary>
        [Fact]
        public void RegisterUserInvalidRequest()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", "danial", "String@123", "String@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region ShouldValidateInvalidFormattedEmail

        /// <summary>
        /// This method is used to test ShouldValidateInvalidFormattedEmail
        /// </summary>
        [Fact]
        public void ShouldValidateInvalidFormattedEmail()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", "danial", "String@123", "String@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert 

            model.Email.Should().NotMatchRegex(RegexExtensions.EmailRegex);

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region ShouldValidateNullEmail

        /// <summary>
        /// This method is used to test ShouldValidateNullEmail
        /// </summary>
        [Fact]
        public void ShouldValidateNullEmail()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", " ", "String@123", "String@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert 

            model.Email.Should().BeNullOrWhiteSpace();

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region ShouldValidateInvalidCharactersInName

        /// <summary>
        /// This method is used to test ShouldValidateInvalidCharactersInName
        /// </summary>
        [Fact]
        public void ShouldValidateInvalidCharactersInName()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL123$", "danial@inlogic.com", "String@123", "String@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert 

            model.Name.Should().NotMatchRegex(RegexExtensions.NameRegex);

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region ShouldValidateInvalidPassword

        /// <summary>
        /// This method is used to test ShouldValidateInvalidPassword
        /// </summary>
        [Fact]
        public void ShouldValidateInvalidPassword()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", "danial@inlogic.com", "string@123", "String@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert 

            model.Password.Should().NotMatchRegex(RegexExtensions.PasswordRegex);

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region ShouldValidateInvalidConfirmPassword

        /// <summary>
        /// This method is used to test ShouldValidateInvalidConfirmPassword
        /// </summary>
        [Fact]
        public void ShouldValidateInvalidConfirmPassword()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", "danial@inlogic.com", "String@123", "string@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert 

            model.ConfirmPassword.Should().NotMatchRegex(RegexExtensions.PasswordRegex);

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #region ShouldValidateMismatchPasswordAndConfirmPassword

        /// <summary>
        /// This method is used to test ShouldValidateMismatchPasswordAndConfirmPassword
        /// </summary>
        [Fact]
        public void ShouldValidateMismatchPasswordAndConfirmPassword()
        {
            #region Arrange

            // validator
            var validator = new UserRegisterRequestModelValidator();

            // model
            var model = new UserRegisterRequestModel("DANIAL", "danial@inlogic.com", "String@1234", "string@123");

            #endregion

            #region Act

            // validate
            var validateResult = validator.Validate(model);

            #endregion

            #region Assert

            model.ConfirmPassword.Should().NotMatch(model.Password);

            // assert
            Assert.False(validateResult.IsValid);

            #endregion
        }

        #endregion

        #endregion

    }
}
