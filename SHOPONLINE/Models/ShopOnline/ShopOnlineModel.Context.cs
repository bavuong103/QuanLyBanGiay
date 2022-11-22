
namespace SHOPONLINE.Models.ShopOnline
{
    using Microsoft.EntityFrameworkCore;
    using System;
    //using System.Data.Entity;
    //using System.Data.Entity.Infrastructure;
    
    public partial class ShopOnlineModel : DbContext
    {
        /*public ShopOnlineModel()
            : base("name=ShopOnline")
        {
        }*/

        public ShopOnlineModel(DbContextOptions<ShopOnlineModel> options) : base(options)
        {
           
        }

        public DbSet<ActionRole> ActionRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MasterRole> MasterRoles { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WebAction> WebActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
        }
    }
}
