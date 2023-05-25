using InLogic.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InLogic.Dependency.Composition
{
    /// <summary>
    /// Represents an service collection ms sql server
    /// </summary>
    public static class ServiceCollectionMsSqlServer
    {
        #region Methods

        #region RegisterMsSqlServer

        /// <summary>
        /// This method is used to register ms sql server
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="connectionString">Connection string</param>
        public static void RegisterMsSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        #endregion

        #endregion 
    }
}
