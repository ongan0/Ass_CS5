﻿using Assignment_CS5_Share._1_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment_CS5_Share._2_Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c=>c.OrderDate).IsRequired();
            builder.Property(c=>c.TotalPrice).IsRequired();
            builder.Property(c=>c.Delivery_Date).IsRequired();
            builder.Property(c=>c.Actual_Delivery_Date).IsRequired();
            builder.Property(c=>c.Delivery_Status).IsRequired();
            builder.Property(c=>c.Shipping_Cost).IsRequired();
            builder.Property(c=>c.Shipping_Address).IsRequired();
            builder.Property(c=>c.Payment_Status).IsRequired();

            
            builder.HasMany(c=>c.BillDetails).WithOne(c=>c.Bill).HasForeignKey(c=>c.ID);
            //builder.HasOne(c => c.Delivery_Address).WithMany(c => c.Bills).HasForeignKey(c => c.Delivery_AddressID);
        }
    }
}
