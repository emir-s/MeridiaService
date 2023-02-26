using System;
using System.Security.AccessControl;
using Meridia.Domain.Entities.Common;
using Meridia.Domain.Entities.Locations;
using Meridia.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;


namespace Meridia.Infrastructure.Data
{
    public class MeridiaDbContext : DbContext
    {
        public MeridiaDbContext(DbContextOptions<MeridiaDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Address> Address { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(c => c.Districts)
                .WithOne(o => o.City)
                .HasForeignKey(o => o.CityID);
            
            modelBuilder.Entity<District>()
                .HasMany(c => c.Addresses)
                .WithOne(o => o.District)
                .HasForeignKey(o => o.DistrictID);
            
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                                   .Where(x => x.State == EntityState.Added)
                                   .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                var auditableEntity = insertedEntry as BaseEntity;
                //If the inserted object is an Auditable. 
                if (auditableEntity != null)
                {
                    auditableEntity.CreatedDate = DateTime.UtcNow;
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                //If the inserted object is an Auditable. 
                var auditableEntity = modifiedEntry as BaseEntity;
                if (auditableEntity != null)
                {
                    auditableEntity.LastUpdatedDate = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }

}

