using _1_AppData._1_DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Quantity).IsRequired();
            builder.Property(c => c.Price).IsRequired();

            builder.HasOne(c => c.Bill).WithMany(c => c.BillDetails).HasForeignKey(c => c.BillID);
            builder.HasOne(c => c.Food).WithMany(c => c.BillDetails).HasForeignKey(c => c.FoodID);
        }
    }
}
