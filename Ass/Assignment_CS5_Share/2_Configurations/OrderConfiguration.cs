using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(c => c.OrderID);
            builder.Property(c => c.OrderDate).IsRequired();
            builder.Property(c=>c.TotalPrice).IsRequired();
            builder.Property(c=>c.Status).IsRequired();

            builder.HasMany(c=>c.OrderDetail).WithOne(c => c.Order).HasForeignKey(c => c.OrderID);
        }
    }
}
