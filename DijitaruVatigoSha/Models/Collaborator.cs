using DijitaruVatigoSha.Dictionaries;
using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Models;

public class Collaborator
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public char Gender { get; set; }
    public DateTime BirthDate { get; set; }

    public string ModalityString { get; private set; }

    public ContractModality Modality
    {
        get { return ModalityString.ToContractModality(); } 
        set { ModalityString = value.ModalityToString();} 
    }
    public string RoleString { get; private set;}

    public Role Role
    { 
        get { return RoleString.ToRole(); }
        set { RoleString = value.RoleToString(); }
    }

    // *** --- relations ------------------------------------------------ *** //

    public required IList<PendingHour> PendingHours { get; set; }
    
    public required IList<PendingHour> ApprovableHours { get; set; }

    public required IList<Project> Projects { get; set; }

    public required IList<Project> ApprovableProjects { get; set; }

    // *** --- constructors --------------------------------------------- *** //

    // public Collaborator()
    // {
    //     PendingHours = new List<PendingHour>();
    //     ApprovableHours = new List<PendingHour>();

    //     ApprovableProjects = new List<Project>();
    //     Projects = new List<Project>();
    // }
}
