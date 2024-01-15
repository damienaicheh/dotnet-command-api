using AutoMapper;
using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class AiPluginProfile : Profile
    {
        public AiPluginProfile()
        {
            //Source -> Target
            CreateMap<AiPlugin, AiPluginDto>();
            CreateMap<Auth, AuthDto>();
            CreateMap<Api, ApiDto>();
        }
    } 
}