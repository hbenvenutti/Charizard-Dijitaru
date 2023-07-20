using DijitaruVatigoSha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DijitaruVatigoSha.Context.Config;
internal class PendingHourConfig : IEntityTypeConfiguration<PendingHour>
{
    public void Configure(EntityTypeBuilder<PendingHour> builder)
    {
        builder
            .HasKey(pendingHour => pendingHour.Id);

        // ------------------------------------------------------------------ //

        builder
            .Property(pendingHour => pendingHour.CollaboratorId)
            .IsRequired();

        builder
            .HasOne(pendingHour => pendingHour.Collaborator)
            .WithMany(collaborator => collaborator.PendingHours)
            // .HasForeignKey("CollaboratorId")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // ------------------------------------------------------------------ //

        builder
            .Property(pendingHour => pendingHour.ProjectId)
            .IsRequired();

        builder
            .HasOne(pendingHour => pendingHour.Project)
            .WithMany(project => project.PendingHours)
            // .HasForeignKey("ProjectId")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // ------------------------------------------------------------------ //

        builder
            .Property(pendingHour => pendingHour.ApproverId);

        builder
            .HasOne(pendingHour => pendingHour.Approver)
            .WithMany(approver => approver.ApprovableHours)
            // .HasForeignKey("CollaboratorId")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
        
        // ------------------------------------------------------------------ //

        builder
            .Property(pendingHour => pendingHour.HourAmount)
            .IsRequired();

        builder
            .Property(pendingHour => pendingHour.IsApproved)
            .HasDefaultValue(false)
            .IsRequired();
    }
}
