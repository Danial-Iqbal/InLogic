using InLogic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InLogic.Data.Data
{
    /// <summary>
    /// Represents an application db context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {

        #region Ctor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        #region Fields

        /// <summary>
        /// Gets or sets the users
        /// </summary>
        public DbSet<User> Users { get; set; } = default!;

        #endregion

        #region Methods

        #region OnModelCreating

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">Model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // on model creating
            base.OnModelCreating(modelBuilder);

            // apply configuration from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion

        #endregion

    }
}
