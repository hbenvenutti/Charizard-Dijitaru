using DijitaruVatigoSha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DijitaruVatigoSha.Context.Config;

public class CollaboratorConfig : IEntityTypeConfiguration<Collaborator>
{
    public void Configure(EntityTypeBuilder<Collaborator> builder)
    {
        builder
            .HasKey(collaborator => collaborator.Id);

        builder
            .Property(collaborator => collaborator.Name)
            .IsRequired();

        builder
            .Property(collaborator => collaborator.Gender)
            .HasColumnType("nchar(1)")
            .IsRequired();

        builder
            .Property(collaborator => collaborator.BirthDate)
            .IsRequired();

        builder
            .Property(collaborator => collaborator.ModalityString)
            .HasColumnName("Modality")
            .IsRequired();

        builder
            .Ignore(collaborator => collaborator.Modality);
        
        builder
            .Property(collaborator => collaborator.GenderString)
            .HasColumnName("Gender")
            .IsRequired();
        
        builder
            .Ignore(collaborator => collaborator.Gender);

        builder
            .Property(collaborator => collaborator.RoleString)
            .HasColumnName("Role")
            .IsRequired();

        builder.Ignore(collaborator => collaborator.Role);

        builder
            .HasMany(collaborator => collaborator.Projects)
            .WithMany(project => project.Collaborators)
            .UsingEntity(join => join.ToTable("CollaboratorProject"));

        builder
            .HasMany(collaborator => collaborator.ApprovableProjects)
            .WithMany(project => project.Approvers)
            .UsingEntity(join => join.ToTable("ProjectApprover"));
    }
}
