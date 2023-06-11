using _1_AppData._1_DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.UserName).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Password).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(526).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(128).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.HasMany(c => c.Orders).WithOne(c => c.Users).HasForeignKey(c => c.UserID);
            builder.HasOne(c => c.Role).WithMany(c => c.Users).HasForeignKey(c => c.IDRole);
        }
    }
}
