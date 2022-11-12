using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.DBContexts;
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
                List<Trial> trials = _trialRepository.GetAllTrials();
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

        [HttpGet]
        [Route("getTrialById/{id}")]
        public IActionResult GetSingleTrial(int id)
        {
            Trial? trial = _trialRepository.GetOneTrial(id);
            TrialDto response = new()
            {
                Distance = trial.Distance,
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("createTrial")]
        public IActionResult CreateTrial (TrialDto dto)
        {
            try
            {
                //List<Meet> meets = GetALLTrials();
                //validateMeetId(meets, dto.MeetId); //validamos que el meet al cual se quiere asignar el trial exista
                Trial newTrial = new()
                {
                    Distance = dto.Distance,
                    Style = dto.Style,
                    MeetId = dto.MeetId,
                };
                TrialDto response = new()
                {
                    Distance = newTrial.Distance,
                    Style = newTrial.Style,
                    MeetId = newTrial.MeetId,
                };
                _trialRepository.AddTrial(newTrial);
                return Created("Trial creado correctamente.", response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteTrial/{id}")]
        public IActionResult DeleteTrial (int id)
        {
            try
            {
                _trialRepository.DeleteTrial(id);
                return Ok("Trial eliminado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void validateMeetId(List<Meet> meets, int Id)
        {
            var meetExists = meets.First(m => m.Id == Id);
            if (meetExists == null)
            {
                throw new Exception("Meet no encontrado, revisar Id.");
            }
        }
        
        
    }
}