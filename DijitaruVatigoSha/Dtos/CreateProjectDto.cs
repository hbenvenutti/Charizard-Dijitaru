using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos;

public class CreateProjectDto
{
    public string Name { get; set; }
    public double Budget { get; set; }
    public ProjectType Type { get; set; }
}
