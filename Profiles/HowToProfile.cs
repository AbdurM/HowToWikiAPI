using AutoMapper;
using HowToWikiAPI.Models;

namespace HowToWikiAPI.Profiles
{
public class HowToProfile : Profile
{
    public HowToProfile()
    {
        CreateMap<HowToItem, HowToReadDto>();
    }
}
}