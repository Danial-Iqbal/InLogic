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

        private readonly IApiKeyValidatorService _apiKeyValidatorService;

        #endregion

        #region Ctor

        public ApiKeyAuthorizationFilter(IApiKeyValidatorService apiKeyValidatorService)
        {
            _apiKeyValidatorService = apiKeyValidatorService;
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
            // read api key from header
            var apiKey = context.HttpContext.Request.Headers[ApplicationConstants.ApiKeyHeaderName];

            // validate key
            if (!_apiKeyValidatorService.IsValid($"{apiKey}"))
            {
                // unauthorized result
                context.Result = new UnauthorizedResult();
            }
        }

        #endregion

        #endregion
    }
}
