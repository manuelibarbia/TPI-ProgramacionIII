using AutoMapper;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Profiles
{
    public class MeetProfile : Profile
    {
        public MeetProfile()
        {
            CreateMap<Entities.Meet, MeetDto>();
        }
    }
}
