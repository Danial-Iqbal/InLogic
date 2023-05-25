using InLogic.Application.Models.Users;
using InLogic.Application.Services.Users;
using InLogic.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace InLogic.WebApi.Controllers
{
    /// <summary>
    /// Represents an books controller
    /// </summary>
    [Route("api/[controller]")]
    [SwaggerTag("User public operations")]
    [ApiKey]
    public class UsersController : BaseController
    {
        #region Properties

        private readonly string _straceId;

        private readonly string _className;

        private readonly IUserService _userService;

        private ILogger<UsersController> _logger;

        #endregion

        #region Ctor

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _straceId = Guid.NewGuid().ToString();
            _className = nameof(UsersController);
            _userService = userService;
            _logger = logger;
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : ctor {_className}");
        }

        #endregion

        #region Methods 

        #region Register

        /// <summary>
        /// This method is used to register user
        /// </summary>
        /// <param name="model">User register model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        [HttpPost("Register")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Successfully registered", typeof(UserRegisterResponseModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Anything wrong with the input", typeof(ProblemDetails))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, "Unauthorized")]
        [SwaggerResponse((int)HttpStatusCode.Forbidden, "Forbidden")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Internal server error", typeof(ProblemDetails))]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model, CancellationToken cancellationToken)
        {
            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Register started");

            // register
            var result = await _userService.RegisterAsync(model, cancellationToken);

            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Register started");

            // return
            return Ok(result);
        }

        #endregion 

        #endregion
    }
}
