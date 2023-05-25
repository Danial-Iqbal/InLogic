using InLogic.Data.Configurations.Users;
using Microsoft.EntityFrameworkCore;

namespace InLogic.Data.Configurations.Common
{
    /// <summary>
    /// Represents an common configuration
    /// </summary>
    internal static class CommonConfiguration
    {
        #region Methods

        #region Apply configuration

        /// <summary>
        /// This method is used to apply configuration
        /// </summary>
        /// <param name="builder">builder</param>
        public static void ApplyConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }

        #endregion

        #endregion

    }
}
