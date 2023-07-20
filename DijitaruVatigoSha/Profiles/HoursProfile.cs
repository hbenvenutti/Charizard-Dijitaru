using AutoMapper;
using DijitaruVatigoSha.Dtos.Hour;
using DijitaruVatigoSha.Models;

namespace DijitaruVatigoSha.Profiles;

public class HoursProfile: Profile
{
    public HoursProfile()
    {
        CreateMap<CreateHoursDto, PendingHour>();
        CreateMap<PendingHour, ReadHoursDto>();
    }
}
