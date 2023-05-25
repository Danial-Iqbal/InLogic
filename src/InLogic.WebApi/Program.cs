
using InLogic.Data.Data;
using InLogic.Dependency.Composition;
using InLogic.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InLogic.WebApi
{
    /// <summary>
    /// Represents an program
    /// </summary>
    public class Program
    {
        #region Methods

        #region Main

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            // cors policy name
            const string corsPolicyName = "CorsPolicy";

            // builder
            var builder = WebApplication.CreateBuilder(args);

            // builder services
            var services = builder.Services;

            // Add services to the container.

            #region Add services

            // mvc customized
            services.MvcCustomized();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            // swagger swagger customized
            services.AddSwaggerCustomized();

            // fluent validation customized
            services.AddFluentValidationCustomized();

            // register ms sql server
            services.RegisterMsSqlServer($"{builder.Configuration.GetConnectionString("DefaultConnection")}");

            // application services
            services.AddApplicationServices();

            // api key authorization filter
            services.AddApiKeyAuthorizationFilter();

            // register repository
            services.RegisterRepository();

            // auto mapper
            services.AddAutoMapperCustomized();

            // add problem details
            services.AddProblemDetails();

            // cors
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    b => b.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            #endregion

            // app
            var app = builder.Build();

            #region App

            app.UseExceptionHandler();

            app.UseStatusCodePages();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            // https redirection
            app.UseHttpsRedirection();

            // authorization
            app.UseAuthorization();

            // cors
            app.UseCors(corsPolicyName);

            InitializeDatabase(app);

            // map controllers
            app.MapControllers();

            // run
            app.Run();

            #endregion
        }


        #endregion

        #region InitializeDatabase

        /// <summary>
        /// This method is used to initialize database (run migrations)
        /// </summary>
        /// <param name="app">Application builder</param>
        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

            serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
        }

        #endregion

        #endregion

    }
}