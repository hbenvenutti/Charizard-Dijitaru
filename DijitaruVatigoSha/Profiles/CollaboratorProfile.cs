using AutoMapper;
using DijitaruVatigoSha.Dtos;
using DijitaruVatigoSha.Dtos.Collaborator;
using DijitaruVatigoSha.Models;

namespace DijitaruVatigoSha.Profiles;

public class CollaboratorProfile: Profile
{
    public CollaboratorProfile()
    {
        CreateMap<CreateCollaboratorDto, Collaborator>();
        CreateMap<Collaborator, ReadCollaboratorDto>();
    }    
}
