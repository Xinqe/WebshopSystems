namespace WebShopUserMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebshopModel : DbContext
    {
        public WebshopModel()
            : base("name=WebshopModel")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItem)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderItem)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
