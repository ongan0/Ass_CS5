using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c=>c.FoodName).HasMaxLength(128).IsRequired();
            builder.Property(c=>c.Price).IsRequired();
            builder.Property(c=>c.Description).HasMaxLength(526).IsRequired();

            builder.HasMany(c=>c.Categorys).WithMany(c=>c.Food); 
            //builder.HasMany(c=>c.BillDetails).WithOne(c=>c.Food).HasForeignKey(c=>c.ID); đã thành công
        }
    }
}
