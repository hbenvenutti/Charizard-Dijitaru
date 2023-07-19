using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Budget { get; set; }
    public ProjectType Type { get; set; }
    public List<Collaborator> Collaborators { get; set; }
    public List<Collaborator> Approvers { get; set; }
    public List<PendingHour> PendingHours { get; set; }
}
