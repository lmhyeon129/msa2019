using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using donation_MERCHANT.Models;


namespace donation_MERCHANT.Repositories
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var stateConverter = new EnumToStringConverter<State>();
            var bizTypeConverter = new EnumToStringConverter<BizType>();
            builder.Entity<Product>()
                .HasKey(p => p.ProdId)
                .HasName("PrimaryKey_ProdId");
            builder.Entity<Product>()
                .Property(p => p.ProdState)
                .HasConversion(stateConverter);
            builder.Entity<Product>()
                .Property(p => p.BizType)
                .HasConversion(bizTypeConverter);
        }
    }
}