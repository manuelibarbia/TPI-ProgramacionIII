using AutoMapper;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Profiles
{
    public class SwimmerProfile : Profile
    {
        public SwimmerProfile()
        {
            CreateMap<Swimmer, SwimmerDto>
        }
    }
}
