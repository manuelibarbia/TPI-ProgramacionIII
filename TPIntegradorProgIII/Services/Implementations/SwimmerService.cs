using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Models;
using TPIntegradorProgIII.Services.Interfaces;

namespace TPIntegradorProgIII.Services.Implementations
{
    public class SwimmerService : ISwimmerService
    {
        private readonly ISwimmerRepository _userRepository;

        public SwimmerService(ISwimmerRepository swimmerRepository)
        {
            _userRepository = swimmerRepository;
        }
        public ICollection<MeetDto> GetMeetsBySwimmer(int swimmerId)
        {
            var meets = _userRepository.GetSwimmerMeets(swimmerId);
            List<MeetDto> result = new List<MeetDto>();
            foreach (var meet in meets)
            {
                result.Add(new MeetDto()
                {
                    MeetDate = meet.MeetDate,
                    Id = meet.Id,
                    MeetName = meet.MeetName,
                    MeetPlace = meet.MeetPlace,
                    ParticipantSwimmers = meet.ParticipantSwimmers
                });
            }
            return result;
            
            //return _mapper.Map<ICollection<MeetDto>>(meets);
        }

        public ICollection<TrialDto> GetTrialsBySwimmer(int swimmerId)
        {
            var trials = _userRepository.GetSwimmerTrials(swimmerId);
            List<TrialDto> result = new List<TrialDto>();
            foreach (var trial in trials)
            {
                result.Add(new TrialDto()
                {
                    Id = trial.Id,
                    Distance = trial.Distance,
                    RegisteredSwimmers = trial.RegisteredSwimmers,
                    Style = trial.Style
                });
            }
            return result;
            //return _mapper.Map<ICollection<TrialDto>>(trials);
        }
    }
}
