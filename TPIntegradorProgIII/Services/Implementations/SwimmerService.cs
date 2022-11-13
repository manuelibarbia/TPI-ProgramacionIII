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

        public ICollection<TrialResponse> GetTrialsBySwimmer(int swimmerId)
        {
            var trials = _userRepository.GetSwimmerTrials(swimmerId);
            List<TrialResponse> result = new List<TrialResponse>();
            foreach (var trial in trials)
            {
                result.Add(new TrialResponse()
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
