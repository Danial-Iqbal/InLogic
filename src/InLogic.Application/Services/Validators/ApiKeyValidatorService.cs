using InLogic.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InLogic.Application.Services.Validators
{
    /// <summary>
    /// Represents an api key validator
    /// </summary>
    public class ApiKeyValidatorService : IApiKeyValidatorService
    {
        #region Fields

        private readonly string _straceId;

        private readonly string _className;

        private readonly IConfiguration _configuration;

        private readonly ILogger<ApiKeyValidatorService> _logger;

        #endregion

        #region Ctor

        public ApiKeyValidatorService(IConfiguration configuration, ILogger<ApiKeyValidatorService> logger)
        {
            _straceId = Guid.NewGuid().ToString();
            _className = nameof(ApiKeyValidatorService);
            _configuration = configuration;
            _logger = logger;
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : ctor {_className}");
        }

        #endregion

        #region Methods

        #region IsValid

        /// <summary>
        /// This method is used to validate api key
        /// </summary>
        /// <param name="apiKey">Api key</param>
        /// <returns>true/false</returns>
        public bool IsValid(string apiKey)
        {
            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} IsValid started");

            // validate
            var isValid = apiKey == _configuration.GetSection(ApplicationConstants.ApiKeyHeaderName).Value;

            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} IsValid ended");

            // return
            return isValid;
        }

        #endregion

        #endregion

    }
}
