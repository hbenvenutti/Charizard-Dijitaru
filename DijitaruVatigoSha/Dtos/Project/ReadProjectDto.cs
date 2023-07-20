using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos.Project;

public class ReadProjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Budget { get; set; }
    public ProjectType Type { get; set; }
}
