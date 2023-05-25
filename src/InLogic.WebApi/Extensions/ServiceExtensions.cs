using InLogic.Common;
using InLogic.WebApi.Filters;
using Microsoft.OpenApi.Models;

namespace InLogic.WebApi.Extensions
{
    /// <summary>
    /// Represents an service extensions
    /// </summary>
    public static class ServiceExtensions
    {
        #region Methods

        #region MvcCustomized

        /// <summary>
        /// MvcCustomized
        /// </summary>
        /// <param name="services">Services</param>
        public static void MvcCustomized(this IServiceCollection services)
        {
            // add controllers
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ApplicationExceptionFilterAttribute));
                options.Filters.Add<ApiKeyAttribute>();
            });
        }

        #endregion

        #region AddSwaggerCustomized

        /// <summary>
        /// AddSwaggerCustomized
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddSwaggerCustomized(this IServiceCollection services)
        {
            // add swagger gen
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = ApplicationConstants.ApplicationName,
                        Version = "v1",
                        Description = "This API will be utilized by web applications",
                        Contact = new OpenApiContact
                        {
                            Name = $"{ApplicationConstants.ApplicationName} Web",
                            Url = new Uri("http://localhost:4200/")
                        }
                    });

                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = ApplicationConstants.ApiKeyHeaderName,
                    Description = "Please enter api key into field",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKey"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        Array.Empty<string>()
                    }
                });

            });
        }

        #endregion

        #region AddApiKeyAuthorizationFilter

        /// <summary>
        /// AddApiKeyAuthorizationFilter
        /// </summary>
        /// <param name="services">Services</param>
        public static void AddApiKeyAuthorizationFilter(this IServiceCollection services)
        {
            // add scoped
            services.AddScoped<ApiKeyAuthorizationFilter>();
        }

        #endregion

        #endregion


    }
}
