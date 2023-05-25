using InLogic.Common;
using InLogic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InLogic.Data.Configurations.Users
{
    /// <summary>
    /// Represents an user configuration
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        #region Methods

        #region Configure

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).HasMaxLength(LengthConstraints.PersonName);

            builder.Property(u => u.Email).HasMaxLength(LengthConstraints.Email);
        }

        #endregion

        #endregion
    }
}
