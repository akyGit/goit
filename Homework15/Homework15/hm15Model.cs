namespace Homework15 {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class hm15Model : DbContext {
        public hm15Model()
            : base("name=hm15Model") {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Sale)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Sale>()
                .Property(e => e.Sum)
                .HasPrecision(19, 4);
        }
    }
}
