namespace DijitaruVatigoSha.Models;

public class PendingHour
{
    public int Id { get; set; }
    public int CollaboratorId { get; set; }
    public int ProjectId { get; set; }
    public int? ApproverId { get; set; }
    public int HourAmount { get; set; }
    public bool IsApproved { get; set; }

    // *** --- relations ------------------------------------------------ *** //

    public required Collaborator Collaborator { get; set; }
    public required Project Project { get; set; }
    public required Collaborator Approver { get; set; }

    // public PendingHour()
    // {
    //     Collaborator = new Collaborator();
    //     Project = new Project();
    //     Approver = new Collaborator();
    // }
}
