using _1_AppData._1_DataProcessing.Models;
using Assignment_CS5_Share._2_Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Context
{
    public class DBContext_Assgiment : DbContext
    {
        public DBContext_Assgiment()
        {

        }
        public DBContext_Assgiment(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=AssgimentCsharp5_Nhom1_ThayHuyDepTrai=));Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BillDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ComboConfiguration());
            modelBuilder.ApplyConfiguration(new CouponsConfiguration());
            modelBuilder.ApplyConfiguration(new Delivery_AddressConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bills)
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Ordel> Orders { get; set; }
        public DbSet<OrderDetail> OrdelDetail { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Delivery_Address> Delivery_Addresses { get; set; }
    }
}
