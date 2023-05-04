using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Infrastructure.Data;
public class ServiceRadarDbContext : IdentityDbContext
{
    public ServiceRadarDbContext(DbContextOptions<ServiceRadarDbContext> options) : base(options) { }

    public DbSet<Workshop> Workshops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure identity tables
        base.OnModelCreating(modelBuilder);

        // Configure a relationship where ContactDetails is owned by Workshop.
        // This means that EF will not create two separate tables,
        // but will add the fields from the Contact Details table to the Workshop table
        // and creates one large table.
        modelBuilder.Entity<Workshop>()
            .OwnsOne(c => c.ContactDetails);
    }
}
