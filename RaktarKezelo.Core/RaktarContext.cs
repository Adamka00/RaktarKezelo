using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using RaktarKezelo.Core.Entities;

namespace RaktarKezelo.Core;

public class RaktarContext : DbContext
{
    public DbSet<Termek> Termekek { get; set; }
    public DbSet<Kategoria> Kategoriak { get; set; }
    public DbSet<Tranzakcio> Tranzakciok { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "server=10.211.55.2;database=raktar_db;user=root;password=Ad123456";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}