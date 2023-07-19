using DijitaruVatigoSha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DijitaruVatigoSha.Context.Config
{
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
                .Property(collaborator => collaborator.Modality)
                .IsRequired();

            builder
                .Property(collaborator => collaborator.CollaboratorRole)
                .IsRequired();
        }
    }
}
    



