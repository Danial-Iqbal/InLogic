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
        #region Methods

        #region OnException

        /// <summary>
        /// OnException
        /// </summary>
        /// <param name="context">Context</param>
        public override void OnException(ExceptionContext context)
        {
            // only handle application exceptions others should return 500 result;
            if (context.Exception is not Application.Exceptions.Common.ApplicationException)
                return;

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
                    return;
            }

            // content type
            context.HttpContext.Response.ContentType = "application/json";

            // status code
            context.HttpContext.Response.StatusCode = problemDetail.Status.GetValueOrDefault();

            // result
            context.Result = new JsonResult(problemDetail);
        }

        #endregion

        #endregion


    }
}
