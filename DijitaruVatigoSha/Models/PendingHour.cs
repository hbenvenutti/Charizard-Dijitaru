namespace DijitaruVatigoSha.Models;

public class PendingHour
{
    public int Id { get; set; }
    public int CollaboratorId { get; set; }
    public int ProjectId { get; set; }
    public int? ApproverId { get; set; } = null;
    public int HourAmount { get; set; }
    public bool IsApproved { get; set; } = false;

    // *** --- relations ------------------------------------------------ *** //

    public required Collaborator Collaborator { get; set; }
    public required Project Project { get; set; }
    public required Collaborator Approver { get; set; }
}
