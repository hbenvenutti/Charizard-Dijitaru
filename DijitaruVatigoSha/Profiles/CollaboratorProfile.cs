using AutoMapper;
using DijitaruVatigoSha.Dtos;
using DijitaruVatigoSha.Models;

namespace DijitaruVatigoSha.Profiles;

public class CollaboratorProfile: Profile
{
    CollaboratorProfile()
    {
        CreateMap<CreateCollaboratorDto, Collaborator>();
    }    
}
