using AutoMapper;
using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Services.Implementations
{
    public class SwimmerService : ISwimmerService
    {
        private readonly ISwimmerRepository _userRepository;
        private readonly IMapper _mapper;

        public SwimmerService(ISwimmerRepository swimmerRepository, IMapper mapper)
        {
            _userRepository = swimmerRepository;
            _mapper = mapper;
        }
        public ICollection<MeetDto> GetMeetsBySwimmer(int swimmerId)
        {
            var meets = _userRepository.GetSwimmerMeets(swimmerId);

            return _mapper.Map<ICollection<MeetDto>>(meets);
        }

        public ICollection<TrialDto> GetTrialsBySwimmer(int swimmerId)
        {
            var trials = _userRepository.GetSwimmerTrials(swimmerId);

            return _mapper.Map<ICollection<TrialDto>>(trials);
        }
    }
}
