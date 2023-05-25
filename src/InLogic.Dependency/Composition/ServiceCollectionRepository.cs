using InLogic.Data;
using InLogic.Data.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InLogic.Dependency.Composition
{
    /// <summary>
    /// Represents an service collection repository
    /// </summary>
    public static class ServiceCollectionRepository
    {
        #region Methods

        #region Register repository

        /// <summary>
        /// This method is used to register repository
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        #endregion

        #endregion

    }
}
