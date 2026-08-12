using Microsoft.EntityFrameworkCore;

namespace MarketInventoryApplication.Data;

public class MarketInventoryContext : DbContext
{
    public MarketInventoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<TransferList> TransferList { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        modelBuilder.Entity<TransferList>()
            .HasOne(t => t.ModifiedByUser)
            .WithMany(u => u.ModifiedTransfers)
            .HasForeignKey(t => t.ModifiedByUserId)
            .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<TransferList>()
            .HasOne(t => t.Product)
            .WithMany()
            .HasForeignKey(t => t.ProductId)
            .OnDelete(DeleteBehavior.Restrict);



        modelBuilder.Entity<TransferList>()
            .HasOne(t => t.Location)
            .WithMany(l => l.Transfers)
            .HasForeignKey(t => t.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}