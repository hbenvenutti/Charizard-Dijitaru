using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos.Collaborator;

public class ReadCollaboratorDto
{   
    public int Id { get; init; }
    public required string Name { get; init; }
    public Gender Gender { get; init; }
    public DateTime BirthDate { get; init; }
    public ContractModality Modality { get; init; }
    public Role Role { get; init; }
}
