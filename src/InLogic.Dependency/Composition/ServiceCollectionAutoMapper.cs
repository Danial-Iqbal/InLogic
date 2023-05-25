using InLogic.Application.Services.Users;
using InLogic.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace InLogic.Dependency.Composition
{
    /// <summary>
    /// Represents an service collection auto mapper
    /// </summary>
    public static class ServiceCollectionAutoMapper
    {
        #region Methods

        #region Add auto mapper

        /// <summary>
        /// This method is used to add auto mapper
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddAutoMapperCustomized(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IUserService), typeof(User));
        }

        #endregion

        #endregion

    }
}
