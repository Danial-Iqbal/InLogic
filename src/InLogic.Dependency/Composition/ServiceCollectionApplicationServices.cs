using InLogic.Application.Services.Users;
using InLogic.Application.Services.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace InLogic.Dependency.Composition
{
    /// <summary>
    /// Represents an service collection application services
    /// </summary>
    public static class ServiceCollectionApplicationServices
    {
        #region Methods

        #region Add application services

        /// <summary>
        /// This method is used to add application services
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApiKeyValidatorService, ApiKeyValidatorService>();
        }

        #endregion

        #endregion

    }
}
