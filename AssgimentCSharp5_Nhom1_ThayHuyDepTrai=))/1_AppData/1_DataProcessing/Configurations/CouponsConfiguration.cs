using _1_AppData._1_DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class CouponsConfiguration : IEntityTypeConfiguration<Coupons>
    {
        public void Configure(EntityTypeBuilder<Coupons> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c=>c.Coupon_Code).HasMaxLength(256).IsRequired();
            builder.Property(c=>c.Discount_Type).IsRequired();
            builder.Property(c=>c.Discount_Amount).IsRequired();
            builder.Property(c=>c.Minimum_Spend).IsRequired();
            builder.Property(c=>c.Maximum_Discount_Amount).IsRequired();
            builder.Property(c=>c.Expiration_Date).IsRequired();
            builder.Property(c=>c.Create_At).IsRequired();

            builder.HasMany(c => c.Food).WithMany(c => c.Coupons);
            builder.HasMany(c=>c.Combo).WithMany(c => c.Coupons);
        }
    }
}
