using Domain.Entites.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyType> BodyTypes { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarInventory> CarInventories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries<BaseEntity>();
        foreach (var entity in entities)
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.Id = Guid.NewGuid();
                    break;

            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasIndex(e => e.BodyTypeId, "IX_Cars_BodyTypeId");
            entity.HasIndex(e => e.BrandId, "IX_Cars_BrandId");
            entity.HasIndex(e => e.CarInventoryId, "IX_Cars_CarInventoryId");
            entity.HasIndex(e => e.TransmissionId, "IX_Cars_TransmissionId");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.HasOne(d => d.BodyType).WithMany(p => p.Cars).HasForeignKey(d => d.BodyTypeId);
            entity.HasOne(d => d.Brand).WithMany(p => p.Cars).HasForeignKey(d => d.BrandId);
            entity.HasOne(d => d.CarInventory).WithMany(p => p.Cars).HasForeignKey(d => d.CarInventoryId);
            entity.HasOne(d => d.Transmission).WithMany(p => p.Cars).HasForeignKey(d => d.TransmissionId);
        });

        modelBuilder.Entity<CarInventory>(entity =>
        {
            entity.HasIndex(e => e.LocationId, "IX_CarInventories_LocationId");
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Location).WithMany(p => p.CarInventories).HasForeignKey(d => d.LocationId);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_Rentals_CarId");

            entity.HasIndex(e => e.CustomerId, "IX_Rentals_CustomerId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Car).WithMany(p => p.Rentals).HasForeignKey(d => d.CarId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
