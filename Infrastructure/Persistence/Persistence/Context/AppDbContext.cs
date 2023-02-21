using Domain.Entites;
using Domain.Entites.Base;
using Domain.Entites.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence.Context;

public partial class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyType> BodyTypes { get; set; }
    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<CarInventory> CarInventories { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Rental> Rentals { get; set; }
    public virtual DbSet<Transmission> Transmissions { get; set; }
    public virtual DbSet<CarModel> CarModels { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries<BaseEntity>();

        foreach (var entity in entities)
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    /// <summary>
    /// 
    /// Configuration
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString.MssqlLocalDb,
            options => options.EnableRetryOnFailure());

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarModel>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_CarModels_BrandId");

            entity.HasOne(d => d.Brand).WithMany(p => p.CarModels).HasForeignKey(p => p.BrandId);
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasIndex(e => e.BodyTypeId, "IX_Cars_BodyTypeId");
            entity.HasIndex(e => e.BrandId, "IX_Cars_BrandId");
            entity.HasIndex(e => e.CarInventoryId, "IX_Cars_CarInventoryId");
            entity.HasIndex(e => e.TransmissionId, "IX_Cars_TransmissionId");
            entity.HasIndex(e => e.CarModelId, "IX_Cars_CarModelId");
            entity.HasIndex(e => e.ColorId, "IX_Cars_ColorId");

            entity.HasOne(d => d.BodyType).WithMany(p => p.Cars).HasForeignKey(d => d.BodyTypeId);
            entity.HasOne(d => d.Brand).WithMany(p => p.Cars).HasForeignKey(d => d.BrandId);
            entity.HasOne(d => d.Color).WithMany(p => p.Cars).HasForeignKey(d => d.ColorId);
            entity.HasOne(d => d.CarInventory).WithMany(p => p.Cars).HasForeignKey(d => d.CarInventoryId);
            entity.HasOne(d => d.Transmission).WithMany(p => p.Cars).HasForeignKey(d => d.TransmissionId);
            entity.HasOne(d => d.CarModel).WithMany(p => p.Cars).HasForeignKey(d => d.CarModelId);
        });

        modelBuilder.Entity<CarInventory>(entity =>
        {
            entity.HasIndex(e => e.LocationId, "IX_CarInventories_LocationId");

            entity.HasOne(d => d.Location).WithMany(p => p.CarInventories).HasForeignKey(d => d.LocationId);
        });


        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasIndex(e => e.CarId, "IX_Rentals_CarId");
            entity.HasIndex(e => e.CustomerId, "IX_Rentals_CustomerId");

            entity.HasOne(d => d.Car).WithMany(p => p.Rentals).HasForeignKey(d => d.CarId);
            entity.HasOne(d => d.Customer).WithMany(p => p.Rentals).HasForeignKey(d => d.CustomerId);
        });
        base.OnModelCreating(modelBuilder);
    }

}
