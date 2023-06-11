using _1_AppData._1_DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class ComboConfiguration : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c=>c.ComboName).HasMaxLength(256).IsRequired();
            builder.Property(c=>c.Price).IsRequired();
            builder.Property(c=>c.Description).HasMaxLength(256).IsRequired();

            builder.HasMany(c=>c.Food).WithMany(c=>c.Combos);
        }
    }
}
