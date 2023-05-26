using InLogic.Application.Services.Validators;
using InLogic.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InLogic.WebApi.Filters
{
    /// <summary>
    /// Represents an api key attribute
    /// </summary>
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        #region Ctor

        public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
        }

        #endregion 
    }

    /// <summary>
    /// Represents an api key authorization filter
    /// </summary>
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        #region Fields

        private readonly string _straceId;

        private readonly string _className;

        private readonly ILogger<ApiKeyAuthorizationFilter> _logger;

        private readonly IApiKeyValidatorService _apiKeyValidatorService;

        #endregion

        #region Ctor

        public ApiKeyAuthorizationFilter(IApiKeyValidatorService apiKeyValidatorService, ILogger<ApiKeyAuthorizationFilter> logger)
        {
            _straceId = Guid.NewGuid().ToString();
            _className = nameof(ApiKeyAuthorizationFilter);
            _logger = logger;
            _apiKeyValidatorService = apiKeyValidatorService;
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : ctor {_className}");
        }

        #endregion

        #region Methods

        #region OnAuthorization

        /// <summary>
        /// OnAuthorization
        /// </summary>
        /// <param name="context">Authorization filter context</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} OnAuthorization started");

            // read api key from header
            var apiKey = context.HttpContext.Request.Headers[ApplicationConstants.ApiKeyHeaderName];

            // validate key
            if (!_apiKeyValidatorService.IsValid($"{apiKey}"))
            {
                // unauthorized result
                context.Result = new UnauthorizedResult();
            }

            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} OnAuthorization ended");
        }

        #endregion

        #endregion
    }
}
