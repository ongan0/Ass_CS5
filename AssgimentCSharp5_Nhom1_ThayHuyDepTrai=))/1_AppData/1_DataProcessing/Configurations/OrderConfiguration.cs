using _1_AppData._1_DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _1_AppData._1_DataProcessing
{
    public class OrderConfiguration : IEntityTypeConfiguration<Ordel>
    {
        public void Configure(EntityTypeBuilder<Ordel> builder)
        {
            builder.HasKey(c => c.OrderID);
            builder.Property(c => c.OrderDate).IsRequired();
            builder.Property(c=>c.TotalPrice).IsRequired();
            builder.Property(c=>c.Status).IsRequired();

            builder.HasMany(c=>c.OrderDetail).WithOne(c => c.Order).HasForeignKey(c => c.OrderID);
        }
    }
}
