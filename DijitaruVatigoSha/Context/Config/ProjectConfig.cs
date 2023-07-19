using DijitaruVatigoSha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DijitaruVatigoSha.Context.Config;

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder
            .HasKey(project => project.Id);

        builder
            .Property(project => project.Name)
            .IsRequired();

        builder
            .Property(project => project.Budget)
            .IsRequired();

        builder
            .Property(project => project.TypeString)
            .HasColumnName("Type")
            .IsRequired();
    }
}
