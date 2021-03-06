namespace WebshopAPI.Models
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

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasMany(e => e.OrderItems)
        //        .WithRequired(e => e.Order)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Product>()
        //        .HasMany(e => e.OrderItems)
        //        .WithRequired(e => e.Product)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
