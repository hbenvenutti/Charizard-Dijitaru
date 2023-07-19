using DijitaruVatigoSha.Context.Config;
using DijitaruVatigoSha.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DijitaruVatigoSha.Context;
public class DijitaruVatigoShaContext : DbContext
{
    public DbSet<Collaborator> Collaborators { get; set; }
    public DbSet<Project> Projects { get; set; }

    public DbSet<PendingHour> PendingHours { get; set; }

    public DijitaruVatigoShaContext(DbContextOptions<DijitaruVatigoShaContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProjectConfig());
        modelBuilder.ApplyConfiguration(new CollaboratorConfig());
        modelBuilder.ApplyConfiguration(new PendingHourConfig());
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=localhost;Database=Dijitaru;Integrated Security=True;TrustServerCertificate=True");
    //}
}
