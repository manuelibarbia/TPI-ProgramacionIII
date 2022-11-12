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
    public class TrialController : ControllerBase
    {
        private readonly ITrialRepository _trialRepository;

        public TrialController(ITrialRepository trialRepository)
        {
            _trialRepository = trialRepository;
        }

        [HttpGet]
        [Route("getAllTrial")]
        public IActionResult GetAllTrial()
        {
            
                List<Trial> trials = _trialRepository.GetAllTrial();
                List<TrialDto> trialsList = new();
                foreach (var trial in trials)
                {
                    TrialDto response = new()
                    {
                        Distance = trial.Distance,
                        Id = trial.Id,
                        Style = trial.Style,
                    };
                    trialsList.Add(response);
                }
                return Ok(trialsList);
            
           
        }

        
        
    }
}