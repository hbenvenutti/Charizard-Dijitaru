using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Models;

public class Collaborator
{
    public int Id { get; set; }
    public string Name { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public ContractModality Modality { get; set; }
    public Role CollaboratorRole { get; set; }

    public IList<PendingHour> PendingHours { get; set; }
    public IList<PendingHour> ApprovedHours { get; set; }

    public Collaborator()
    {
        PendingHours = new List<PendingHour>();
        ApprovedHours = new List<PendingHour>();
    }
}
