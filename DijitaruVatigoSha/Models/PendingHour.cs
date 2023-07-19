﻿namespace DijitaruVatigoSha.Models;

public class PendingHour
{
    public int Id { get; set; }
    public int CollaboratorId { get; set; }
    public int ProjectId { get; set; }
    public int? ApproverId { get; set; }
    public int HourAmount { get; set; }
    public bool IsApproved { get; set; }

    public Collaborator Collaborator { get; set; }
    public Project Project { get; set; }
    public Collaborator Approver { get; set; }

    public PendingHour()
    {
        Collaborator = new Collaborator();
        Project = new Project();
        Approver = new Collaborator();
    }
}
