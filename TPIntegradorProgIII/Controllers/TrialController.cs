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
        [Route("getAllTrials")]
        public IActionResult GetAllTrials()
        {
                List<Trial> trials = _trialRepository.GetTrials();
                List<TrialResponse> trialsList = new();
                foreach (var trial in trials)
                {
                    TrialResponse response = new()
                    {
                        Id = trial.Id,
                        Distance = trial.Distance,
                        Style = trial.Style,
                    };
                    trialsList.Add(response);
                }
                return Ok(trialsList);
        }

        [HttpGet]
        [Route("getTrialById/{id}")]
        public IActionResult GetTrialByiD(int id)
        {
            Trial? trial = _trialRepository.GetSingleTrial(id);
            TrialResponse response = new()
            {
                Id = trial.Id,
                Distance = trial.Distance,
                Style = trial.Style
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("createTrial")]
        public IActionResult CreateTrial (AddTrialRequest request)
        {
            try
            {
                //List<Meet> meets = GetALLTrials();
                //ValidateMeetId(meets, request.MeetId); //validamos que el meet al cual se quiere asignar el trial exista
                Trial newTrial = new()
                {
                    Distance = request.Distance,
                    Style = request.Style,
                    MeetId = request.MeetId
                };
                TrialResponse response = new()
                {
                    Distance = newTrial.Distance,
                    Style = newTrial.Style,
                    MeetId = newTrial.MeetId
                };
                _trialRepository.AddTrial(newTrial);
                return Created("Trial creado", response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteTrial/{id}")]
        public IActionResult DeleteTrial(int id)
        {
            try
            {
                _trialRepository.RemoveTrial(id);
                return Ok("Trial borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateMeetId(List<Meet> meets, int Id)
        {
            var meetExists = meets.First(m => m.Id == Id);
            if (meetExists == null)
            {
                throw new Exception("Meet no encontrado, revisar Id.");
            }
        }
    }
}