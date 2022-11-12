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
                    Style = trial.Style
                });
            }
            return result;
            //return _mapper.Map<ICollection<TrialDto>>(trials);
        }
    }
}
