using DijitaruVatigoSha.Context.Config;
using DijitaruVatigoSha.Models;
using Microsoft.EntityFrameworkCore;

namespace DijitaruVatigoSha.Context;
public class DijitaruVatigoShaContext : DbContext
{
    public DbSet<Collaborator> Collaborators { get; set; }
    public DbSet<Project> Projects { get; set; }

    public DbSet<PendingHour> Hours { get; set; }

    public DijitaruVatigoShaContext(DbContextOptions<DijitaruVatigoShaContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProjectConfig());
        modelBuilder.ApplyConfiguration(new CollaboratorConfig());
        modelBuilder.ApplyConfiguration(new PendingHourConfig());
    }
}
