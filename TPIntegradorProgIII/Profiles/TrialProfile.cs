using AutoMapper;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Profiles
{
    public class TrialProfile : Profile
    {
        public TrialProfile()
        {
            CreateMap<Entities.Trial, TrialDto>();
        }
    }
}