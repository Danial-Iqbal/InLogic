using InLogic.Application.Exceptions.Common;
using InLogic.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InLogic.WebApi.Filters
{
    /// <summary>
    /// Represents an application exception filter attribute
    /// </summary>
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Fields

        private readonly string _straceId;

        private readonly string _className;

        private readonly ILogger<ApplicationExceptionFilterAttribute> _logger;

        #endregion

        #region Ctor

        public ApplicationExceptionFilterAttribute(ILogger<ApplicationExceptionFilterAttribute> logger)
        {
            _straceId = Guid.NewGuid().ToString();
            _className = nameof(ApplicationExceptionFilterAttribute);
            _logger = logger;
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : ctor {_className}");
        }

        #endregion

        #region Methods

        #region OnException 

        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context">Context</param>
        public override void OnException(ExceptionContext context)
        {
            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} OnException started");

            // only handle application exceptions others should return 500 result;
            if (context.Exception is not Application.Exceptions.Common.ApplicationException)
            {
                // log information
                _logger.LogError($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Exception Message: {context.Exception.Message}");

                // log error
                _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} OnException ended");

                return;
            }

            // problem detail
            var problemDetail = new ProblemDetails();

            switch (context.Exception)
            {
                case DuplicateOperationException duplicateOperationException:
                    problemDetail.Title = duplicateOperationException.Title;
                    problemDetail.Status = StatusCodes.Status400BadRequest;
                    problemDetail.Detail = duplicateOperationException.Detail;
                    problemDetail.Instance = duplicateOperationException.Instance;
                    problemDetail.Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
                    problemDetail.Extensions.Add("code", ErrorCodes.ExceptionCodes.DuplicateOperation);
                    problemDetail.Extensions.Add("traceId", duplicateOperationException.TraceId);
                    break;
                default:
                    // log error
                    _logger.LogError($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Exception Message: {context.Exception.Message}");
                    // log information
                    _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} OnException ended");
                    return;
            }

            // log error
            _logger.LogError($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Exception Message: {problemDetail.Title}");

            // content type
            context.HttpContext.Response.ContentType = "application/json";

            // status code
            context.HttpContext.Response.StatusCode = problemDetail.Status.GetValueOrDefault();

            // result
            context.Result = new JsonResult(problemDetail);

            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} OnException ended");
        }

        #endregion

        #endregion


    }
}
