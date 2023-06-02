using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class ReviewsConfiguration : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasOne(c => c.Food).WithMany(c => c.Reviews).HasForeignKey(c => c.FoodID);
            builder.HasOne(c => c.User).WithMany(c => c.Reviews).HasForeignKey(c => c.UserID);
        }
    }
}
