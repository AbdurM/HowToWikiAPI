using AutoMapper;
using HowToWikiAPI.Dtos;
using HowToWikiAPI.Models;

namespace HowToWikiAPI.Profiles
{
public class HowToProfile : Profile
{
    public HowToProfile()
    {
        // HowToItem to HowToRead item
        CreateMap<HowToItem, HowToReadDto>();

        //HowToCreate to HowToItem
        CreateMap<HowToCreateDto, HowToItem>();
    }
}
}