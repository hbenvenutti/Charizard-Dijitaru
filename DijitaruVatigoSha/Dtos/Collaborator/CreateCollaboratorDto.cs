using DijitaruVatigoSha.Enums;

namespace DijitaruVatigoSha.Dtos;

public class CreateCollaboratorDto
{
    public required string Name { get; init; }
    public Gender Gender { get; init; }
    public DateTime BirthDate { get; init; }
    public ContractModality Modality { get; init; }
    public Role Role { get; init; }
}
