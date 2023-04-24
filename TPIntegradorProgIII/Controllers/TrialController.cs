using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository;
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
                List<TrialResponse> trialsToReturn = new();
                List<Trial> trials = _trialRepository.GetTrials();
                foreach (var trial in trials)
                {
                    trial.MeetName = _trialRepository.GetTrialMeetName(trial.MeetId);
                    trial.RegisteredSwimmers = _trialRepository.GetRegisteredSwimmers(trial.Id);
                    TrialResponse response = new()
                    {
                        Id = trial.Id,
                        Distance = trial.Distance,
                        Style = trial.Style,
                        MeetName = trial.MeetName,
                        RegisteredSwimmers = trial.RegisteredSwimmers,
                        MeetId = trial.MeetId,
                    };
                    trialsToReturn.Add(response);
                }
                return Ok(trialsToReturn);
        }

        [HttpGet]
        [Route("getTrialById/{id}")]
        public IActionResult GetTrialByiD(int id)
        {
            Trial? trial = _trialRepository.GetSingleTrial(id);
            trial.MeetName = _trialRepository.GetTrialMeetName(trial.MeetId);
            trial.RegisteredSwimmers = _trialRepository.GetRegisteredSwimmers(trial.Id);
            TrialResponse response = new()
            {
                Id = trial.Id,
                Distance = trial.Distance,
                Style = trial.Style,
                MeetName = trial.MeetName,
                RegisteredSwimmers = trial.RegisteredSwimmers,
                MeetId = trial.MeetId
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("createTrial")]
        public IActionResult CreateTrial (AddTrialRequest request)
        {
            try
            {
                List<Meet> meets = _trialRepository.GetExistingMeets();
                ValidateMeetId(meets, request.MeetId);
                Trial newTrial = new()
                {
                    Distance = request.Distance,
                    Style = request.Style,
                    MeetId = request.MeetId
                };
                newTrial.MeetName = _trialRepository.GetTrialMeetName(newTrial.MeetId);
                TrialResponse response = new()
                {
                    Distance = newTrial.Distance,
                    Style = newTrial.Style,
                    MeetName = newTrial.MeetName
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

        [HttpPut]
        [Route("modifyTrialDistance/{id}/{newDistance}")]
        public IActionResult ModifyTrialDistance(int id, int newDistance)
        {
            try
            {
                _trialRepository.EditTrialDistance(id, newDistance);
                return Ok("Distancia modificada");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifyTrialStyle/{id}/{newStyle}")]
        public IActionResult ModifyTrialStyle(int id, string newStyle)
        {
            try
            {
                _trialRepository.EditTrialStyle(id, newStyle);
                return Ok("Estilo modificado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateMeetId(List<Meet> meets, int meetId)
        {
            var meetExists = meets.FirstOrDefault(m => m.Id == meetId);
            if (meetExists == null)
            {
                throw new Exception("Meet no encontrado, revisar Id.");
            }
        }
    }
}