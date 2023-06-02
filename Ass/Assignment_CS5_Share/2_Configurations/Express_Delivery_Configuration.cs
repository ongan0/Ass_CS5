using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class Express_Delivery_Configuration : IEntityTypeConfiguration<Express_Delivery>
    {
        public void Configure(EntityTypeBuilder<Express_Delivery> builder)
        {
            builder.HasKey(c => c.ID);

            //builder.HasOne(c => c.Users).WithMany(c => c.Express_Delivery).HasForeignKey(c => c.IDUser);
        }
    }
}
