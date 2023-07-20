using DijitaruVatigoSha.Dictionaries;
using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Models;

public class Project
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Budget { get; set; }

    public string TypeString { get; private set; }
    public ProjectType Type 
    { 
        get { return TypeString.ToProjectType(); }
        set { TypeString = value.ProjectTypeToString(); } 
    }

    // *** --- relations ------------------------------------------------ *** //
    
    public IList<Collaborator> Collaborators { get; set; }
    public IList<Collaborator> Approvers { get; set; }
    public IList<PendingHour> PendingHours { get; set; }

    // *** --- constructors --------------------------------------------- *** //

    public Project()
    {
        Collaborators = new List<Collaborator>();
        Approvers = new List<Collaborator>();
        PendingHours = new List<PendingHour>();
    }
}
