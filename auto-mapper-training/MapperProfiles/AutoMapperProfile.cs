using auto_mapper_training.Dtos;
using auto_mapper_training.Models;
using AutoMapper;

namespace auto_mapper_training.MapperProfiles
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDto>();
            CreateMap<SuperHeroDto, SuperHero>();
        }
    }
}
