using AutoMapper;
using DijitaruVatigoSha.Dtos.Project;
using DijitaruVatigoSha.Models;

namespace DijitaruVatigoSha.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        CreateMap<Project, ReadProjectDto>();
    }
}
