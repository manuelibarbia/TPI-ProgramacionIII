using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SwimmersTrialsController : ControllerBase
    {
        private readonly ISwimmersTrialsRepository _swimmersTrialsRepository;
        public SwimmersTrialsController(ISwimmersTrialsRepository swimmersTrialsRepository)
        {
            _swimmersTrialsRepository = swimmersTrialsRepository;
        }

        [HttpPost]
        [Route("registerSwimmerToTrial")]
        public IActionResult RegisterSwimmerToTrial (AddSwimmersTrialsRequest request)
        {
            try
            {
                List<Swimmer> swimmers = _swimmersTrialsRepository.GetExistingSwimmers();
                List<Trial> trials = _swimmersTrialsRepository.GetExistingTrials();

                ValidateSwimmerId(swimmers, request.SwimmerId);
                ValidateTrialId(trials, request.TrialId);
                //SwimmersTrials newSwimmersTrials = new()
                //{
                //    RegisteredSwimmersId = request.SwimmerId,
                //}

                _swimmersTrialsRepository.AddSwimmerToTrial(request.SwimmerId, request.TrialId);

                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateSwimmerId(List<Swimmer> swimmers, int swimmerId)
        {
            var swimmerExists = swimmers.FirstOrDefault(s => s.Id == swimmerId);
            if (swimmerExists == null)
            {
                throw new Exception("Nadador no encontrado, revisar Id.");
            }
        }

        [NonAction]
        public void ValidateTrialId(List<Trial> trials, int trialId)
        {
            var trialExists = trials.FirstOrDefault(t => t.Id == trialId);
            if (trialExists == null)
            {
                throw new Exception("Trial no encontrado, revisar Id.");
            }
        }
    }
}
