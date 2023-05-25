namespace InLogic.Application.Services.Validators
{
    /// <summary>
    /// Represents an api key validator
    /// </summary>
    public interface IApiKeyValidatorService
    {
        #region Methods

        #region IsValid

        /// <summary>
        /// This method is used to validate api key
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <returns>true/false</returns>
        bool IsValid(string apiKey);

        #endregion

        #endregion
    }
}
