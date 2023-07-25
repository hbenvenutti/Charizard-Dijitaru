namespace DijitaruVatigoSha.Dtos.Hour;

public class CreateHoursDto
{
    public int CollaboratorId { get; init; }
    public int ProjectId { get; init; }
    public int HourAmount { get; init; }
}
