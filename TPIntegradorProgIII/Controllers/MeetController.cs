using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository;
using TPIntegradorProgIII.Data.Repository.Implementations;
using TPIntegradorProgIII.Data.Repository.Interfaces;
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
                List<Meet> meets = _meetRepository.GetAllMeets();
                List<MeetDto> meetsList = new();
                foreach (var meet in meets)
                {
                    MeetDto response = new()
                    {
                        MeetName = meet.MeetName,
                        MeetDate = meet.MeetDate,
                        MeetPlace = meet.MeetPlace,
                        Id = meet.Id,
                    };
                    meetsList.Add(response);
                }
                return Ok(meetsList);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("getMeetById/{id}")]
        public IActionResult GetSingleMeet(int id)
        {
            try
            {
                Meet? meet = _meetRepository.GetSingleMeet(id);
                MeetDto response = new()
                {
                    MeetName = meet.MeetName,
                    MeetDate = meet.MeetDate,
                    MeetPlace = meet.MeetPlace,
                    Id = meet.Id,
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("addMeet")]
        public IActionResult AddMeet(CreateMeetDto dto)
        {
            try
            {
                List<Meet> meets = _meetRepository.GetAllMeets();

                Meet meet = new()
                {
                    MeetPlace = dto.MeetPlace,
                    MeetName = dto.MeetName,
                    MeetDate = dto.MeetDate,
                };
                MeetDto response = new()
                {
                    MeetPlace = dto.MeetPlace,
                    MeetName = dto.MeetName,
                    MeetDate = dto.MeetDate,
                };
                _meetRepository.AddMeet(meet);
                return Created("Meet creado", response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("removeMeet/{id}")]
        public IActionResult DeleteMeet(int id)
        {
            try
            {
                _meetRepository.DeleteMeet(id);
                return Ok("Meet borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifyMeetDate/{id}")]
        public IActionResult ModifyMeetDate (int id, string newMeetDate)
        {
            try
            {
                _meetRepository.ModifyMeetDate(id, newMeetDate);
                return Ok("Fecha modificada");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}





