using AutoMapper;
using InLogic.Application.Exceptions.Common;
using InLogic.Application.Models.Users;
using InLogic.Common;
using InLogic.Data;
using InLogic.Data.Entities;
using Microsoft.Extensions.Logging;

namespace InLogic.Application.Services.Users
{
    /// <summary>
    /// Represents an user service
    /// </summary>
    public class UserService : IUserService
    {
        #region Fields

        private readonly string _straceId;

        private readonly string _className;

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<UserService> _logger;

        #endregion

        #region Ctor

        public UserService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _straceId = Guid.NewGuid().ToString();
            _className = nameof(UserService);
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : ctor {_className}");
        }

        #endregion

        #region Methods

        #region Register

        /// <summary>
        /// This method is used to register user
        /// </summary>
        /// <param name="model">User register request model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User register response model</returns>
        public async Task<UserRegisterResponseModel> RegisterAsync(UserRegisterRequestModel model, CancellationToken cancellationToken)
        {
            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Register started");

            // get user by email
            var user = await _unitOfWork.UserRepository.GetByEmail(model.Email);

            // duplicate check
            if (user is not null)
            {
                // log information
                _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Register ended");

                // throw user already exists exception
                throw new DuplicateOperationException(_straceId, ErrorCodes.EntityCodes.UserAlreadyExists, ErrorMessages.EntityMessages.UserAlreadyExists, nameof(User));
            }

            // user mapping
            user = _mapper.Map<User>(model);

            // add
            await _unitOfWork.UserRepository.AddAsync(user);

            // save changes
            await _unitOfWork.CompleteAsync();

            // response
            var response = _mapper.Map<UserRegisterResponseModel>(user);

            // log information
            _logger.LogInformation($"Trace Id - {_straceId}, UTC - {DateTime.UtcNow.ToLongDateString()} : {_className} Register ended");

            // return
            return response;
        }

        #endregion

        #endregion

    }
}
