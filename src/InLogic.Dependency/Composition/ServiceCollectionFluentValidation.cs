using FluentValidation;
using FluentValidation.AspNetCore;
using InLogic.Application.Models.Users;
using InLogic.Application.Services.Users;
using InLogic.Application.Validators.Users;
using Microsoft.Extensions.DependencyInjection;

namespace InLogic.Dependency.Composition
{
    /// <summary>
    /// Represents an service collection fluent validation
    /// </summary>
    public static class ServiceCollectionFluentValidation
    {
        #region Methods

        #region Add 

        /// <summary>
        /// This method is used to add fluent validation customized
        /// </summary>
        /// <param name="services">Services</param> 
        public static void AddFluentValidationCustomized(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<UserRegisterRequestModel>, UserRegisterRequestModelValidator>();

            services.AddValidatorsFromAssemblyContaining<UserRegisterRequestModelValidator>();

            services.AddValidatorsFromAssemblyContaining<IUserService>();


        }

        #endregion

        #endregion
    }
}
