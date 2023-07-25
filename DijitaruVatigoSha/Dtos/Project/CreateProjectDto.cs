using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos.Project;

public class CreateProjectDto
{
    public string Name { get; init; }
    public double Budget { get; init; }
    public ProjectType Type { get; init; }
}
