using Microsoft.EntityFrameworkCore;
using MRV.Lead.Domain.Models;
using MRV.Lead.Infra.Maps;

namespace MRV.Lead.Infra.Context;

public class AppDbContext : DbContext
{
    public DbSet<LeadModel> Lead { get; set; }
    public DbSet<ContactModel> Contact { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContactMap());
        modelBuilder.ApplyConfiguration(new LeadMap());
    }
}