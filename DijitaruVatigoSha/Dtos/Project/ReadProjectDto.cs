using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos.Project;

public class ReadProjectDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public double Budget { get; init; }
    public ProjectType Type { get; init; }
}
