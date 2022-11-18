using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MeetController : ControllerBase
    {

        private readonly IMeetRepository _meetRepository;

        public MeetController(IMeetRepository meetRepository)
        {
            _meetRepository = meetRepository;
        }

        [HttpGet]
        [Route("getAllMeets")]
        public IActionResult GetAllMeets()
        {

            try
            {
                List<MeetResponse> meetsToReturn = new List<MeetResponse>();
                List<Meet> meets = _meetRepository.GetMeets();
                foreach (var meet in meets)
                {
                    List<Trial> Trials = _meetRepository.GetTrials(meet.Id);
                    List<string> MeetTrialsWithData = GetMeetTrialsWithData(Trials);
                    MeetResponse response = new()
                    {
                        Id = meet.Id,
                        MeetName = meet.MeetName,
                        MeetDate = meet.MeetDate,
                        MeetPlace = meet.MeetPlace,
                        Trials = MeetTrialsWithData
                    };
                    meetsToReturn.Add(response);
                }
                return Ok(meetsToReturn);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("getMeetById/{id}")]
        public IActionResult GetMeetById(int id)
        {
            try
            {
                Meet? meet = _meetRepository.GetSingleMeet(id);
                List<Trial> Trials = _meetRepository.GetTrials(meet.Id);
                List<string> MeetTrialsWithData = GetMeetTrialsWithData(Trials);
                MeetResponse response = new()
                {
                    MeetName = meet.MeetName,
                    MeetDate = meet.MeetDate,
                    MeetPlace = meet.MeetPlace,
                    Id = meet.Id,
                    Trials = MeetTrialsWithData
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("createMeet")]
        public IActionResult CreateMeet(AddMeetRequest request)
        {
            try
            {
                Meet newMeet = new()
                {
                    MeetPlace = request.MeetPlace,
                    MeetName = request.MeetName,
                    MeetDate = request.MeetDate,
                };
                MeetResponse response = new()
                {
                    MeetPlace = newMeet.MeetPlace,
                    MeetName = newMeet.MeetName,
                    MeetDate = newMeet.MeetDate,
                };
                _meetRepository.AddMeet(newMeet);
                return Created("Meet creado", response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteMeet/{id}")]
        public IActionResult DeleteMeet(int id)
        {
            try
            {
                _meetRepository.RemoveMeet(id);
                return Ok("Meet borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifyMeetDate/{id}/{newMeetDate}")]
        public IActionResult ModifyMeetDate (int id, string newMeetDate)
        {
            try
            {
                _meetRepository.EditMeetDate(id, newMeetDate);
                return Ok("Fecha modificada");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public List<string> GetMeetTrialsWithData (List<Trial> trials)
        {
            List<string> MeetTrialsWithData = new List<string>();
            if (trials.Count() == 0)
            {
                MeetTrialsWithData.Add("No hay trials asignados a este meet");
                return MeetTrialsWithData;
            }
            foreach (Trial trial in trials)
            {
                MeetTrialsWithData.Add("Id: " + trial.Id.ToString() + ", " + trial.Style + " " + trial.Distance + " metros");
            }
            return MeetTrialsWithData;
        }
    }
}





