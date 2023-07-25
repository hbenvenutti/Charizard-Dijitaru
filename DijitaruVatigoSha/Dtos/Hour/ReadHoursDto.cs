namespace DijitaruVatigoSha.Dtos.Hour;

public class ReadHoursDto
{
    public int Id { get; init; }
    public int CollaboratorId { get; init; }
    public int ProjectId { get; init; }
    public int? ApproverId { get; init; }
    public int HourAmount { get; init; }
    public bool IsApproved { get; init; }
}
