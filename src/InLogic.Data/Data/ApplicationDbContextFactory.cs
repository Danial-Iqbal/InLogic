using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InLogic.Data.Data
{
    /// <summary>
    /// Represents an application db context factory
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        #region Methods

        #region CreateDbContext

        /// <summary>
        /// Create db context
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns></returns> 
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // options builder
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // this is only design time so we have no issue hard coding local connection string here.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InLogic;Trusted_Connection=True;MultipleActiveResultSets=true", o =>
            {

            });

            // return application db context
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        #endregion

        #endregion

    }
}
