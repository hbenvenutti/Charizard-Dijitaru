using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos;

public class CreateCollaboratorDto
{
    public required string Name { get; init; }
    public char Gender { get; init; }
    public DateTime BirthDate { get; init; }
    public ContractModality Modality { get; init; }
    public Role CollaboratorRole { get; init; }
}
