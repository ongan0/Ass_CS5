using _1_AppData._1_DataProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_CS5_Share._2_Configurations
{
    public class Delivery_AddressConfiguration : IEntityTypeConfiguration<Delivery_Address>
    {
        public void Configure(EntityTypeBuilder<Delivery_Address> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Receiver_Name).IsRequired();
            builder.Property(c => c.Receiver_Address).IsRequired();
            builder.Property(c => c.PhoneNumber).IsRequired();
            //public string Receiver_Name { get; set; }
            //public string Receiver_Address { get; set; }
            //public string PhoneNumber { get; set; }
            //builder.HasOne(c => c.User).WithMany(c => c.Delivery_Addresses).HasForeignKey(c => c.CustomerID);
        }
    }
}
