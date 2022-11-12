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
        [Route("getAllMeet")]
        public IActionResult GetAllMeets()
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
                   Id=meet.Id,
                };
                meetsList.Add(response);
            }
            return Ok(meetsList);

        }

        [HttpGet]
        [Route("getOneMeet/{id}")]
        public IActionResult GetOneMeet(int id)
        {
            Meet? meet = _meetRepository.GetOneMeet(id);
            MeetDto response = new()
            {
                MeetName = meet.MeetName,
                MeetDate = meet.MeetDate,
                MeetPlace = meet.MeetPlace,
                Id = meet.Id,
            };
            return Ok(response);
        }

        [HttpDelete]
        [Route("removeMeet/{id}")]
        public IActionResult DeleteMeet(int id)
        {
            _meetRepository.DeleteMeet(id);
            return Ok("Meet borrado");
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
                return Created("Usuario creado", response);
            }
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }

    }

}





