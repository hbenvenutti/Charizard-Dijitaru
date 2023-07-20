namespace DijitaruVatigoSha.Dtos.Hour;

public class ReadHoursDto
{
    public int Id { get; set; }
    public int CollaboratorId { get; set; }
    public int ProjectId { get; set; }
    public int? ApproverId { get; set; } = null;
    public int HourAmount { get; set; }
    public bool IsApproved { get; set; } = false;
}
